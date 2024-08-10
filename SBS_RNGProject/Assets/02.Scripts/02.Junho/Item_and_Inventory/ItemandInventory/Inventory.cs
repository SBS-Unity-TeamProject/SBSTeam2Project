using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour, ISaveManager
{
    public static Inventory Instance;

    public int gold;
    public List<InventoryItem> item;
    public Dictionary<ItemData, InventoryItem> ItemDictionary;

    public InventoryItem[] currentFactory;


    [Header("UI")]
    [SerializeField] private Transform inventorySlotParent;
    [SerializeField] private Transform currentFactorySlotParent;
    [SerializeField] private Transform popUpFactoryUI;
    private UI_ItemSlot[] inventoryItemSlot;
    private UI_CurrentFactory[] currentFactorySlot;
    private UI_PopUpFactory[] popUpFactorySlot;


    [Header("Data base")]
    public List<ItemData> itemDataBase;
    public List<InventoryItem> loadedItems;

    [Space]
    public List<ItemData> rareItems;
    public List<ItemData> uniqueItems;
    public List<ItemData> epicItems;
    public List<ItemData> legendItems;

    [SerializeField] private ItemData test;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void Start()
    {
        rareItems = new List<ItemData>();
        uniqueItems = new List<ItemData>();
        epicItems = new List<ItemData>();
        legendItems = new List<ItemData>();
        InitializeItemLists();

        item = new List<InventoryItem>();
        ItemDictionary = new Dictionary<ItemData, InventoryItem>();
        currentFactory = new InventoryItem[5];

        inventoryItemSlot = inventorySlotParent.GetComponentsInChildren<UI_ItemSlot>();
        currentFactorySlot = currentFactorySlotParent.GetComponentsInChildren<UI_CurrentFactory>();
        popUpFactorySlot = popUpFactoryUI.GetComponentsInChildren<UI_PopUpFactory>();

        StartingItem();
        UpdateSlotUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            AddItem(test);
        }
    }

    private void StartingItem()
    {
        if (loadedItems.Count > 0)
        {
            foreach (InventoryItem item in loadedItems)
            {
                for (int i = 0; i < item.stackSize; i++)
                {
                    AddItem(item.data);
                }
            }
        }
    }

    private void InitializeItemLists()
    {
#if UNITY_EDITOR
        string rarePath = "Assets/05.Data/Item/Rare";
        string uniquePath = "Assets/05.Data/Item/Unique";
        string epicPath = "Assets/05.Data/Item/Epic";
        string legendPath = "Assets/05.Data/Item/Legend";

        rareItems = LoadItemsFromPath(rarePath);
        uniqueItems = LoadItemsFromPath(uniquePath);
        epicItems = LoadItemsFromPath(epicPath);
        legendItems = LoadItemsFromPath(legendPath);
#endif
    }

    private List<ItemData> LoadItemsFromPath(string path)
    {
        List<ItemData> items = new List<ItemData>();
        string[] assetGuids = AssetDatabase.FindAssets("t:ItemData", new[] { path });

        foreach (string guid in assetGuids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            ItemData item = AssetDatabase.LoadAssetAtPath<ItemData>(assetPath);
            if (item != null)
            {
                items.Add(item);
            }
        }

        return items;
    }


    private void AddItem(ItemData _item)
    {
        if (_item == null)
        {
            Debug.LogError("Attempted to add a null item to inventory.");
            return;
        }

        if (ItemDictionary.TryGetValue(_item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(_item);
            item.Add(newItem);
            ItemDictionary.Add(_item, newItem);
        }

        UpdateSlotUI();
    }


    public void RemoveItem(ItemData _item)
    {
        if (ItemDictionary.TryGetValue(_item, out InventoryItem value))
        {
            if (value.stackSize <= 1)
            {
                item.Remove(value);
                ItemDictionary.Remove(_item);
            }
            else
            {
                value.RemoveStack();
            }
        }

        UpdateSlotUI();
    }


    public void EquipFactory(InventoryItem factoryItem, int sequence)
    {
        if (sequence >= 0 && sequence < currentFactory.Length)
        {
            UnequipFactory(sequence);

            currentFactory[sequence] = factoryItem;
            RemoveItem(factoryItem.data);

            UpdateSlotUI();
        }
    }

    public void UnequipFactory(int index)
    {
        if (currentFactory[index] != null)
        {
            AddItem(currentFactory[index].data);
            currentFactory[index] = null;

            UpdateSlotUI();
        }
    }


    private void UpdateSlotUI()
    {
        if (inventoryItemSlot == null || currentFactorySlot == null || popUpFactorySlot == null)
        {
            Debug.LogError("UI slots not initialized properly.");
            return;
        }

        for (int i = 0; i < inventoryItemSlot.Length; i++)
        {
            inventoryItemSlot[i].CleanUpSlot();
        }

        for (int i = 0; i < item.Count && i < inventoryItemSlot.Length; i++)
        {
            inventoryItemSlot[i].UpdateSlot(item[i]);
        }

        for (int i = 0; i < currentFactorySlot.Length; i++)
        {
            currentFactorySlot[i].CleanUpSlot();
        }

        for (int i = 0; i < currentFactory.Length && i < currentFactorySlot.Length; i++)
        {
            currentFactorySlot[i].UpdateSlot(currentFactory[i]);
        }

        for (int i = 0; i < popUpFactorySlot.Length; i++)
        {
            popUpFactorySlot[i].CleanUpSlot();
        }

        for (int i = 0; i < currentFactory.Length && i < popUpFactorySlot.Length; i++)
        {
            popUpFactorySlot[i].UpdateSlot(currentFactory[i]);
        }
    }


    #region Gacha
    public void RandomRare()
    {
        int random = Random.Range(0, rareItems.Count);
        AddItem(rareItems[random]);
    }
    public void RandomUnique()
    {
        int random = Random.Range(0, uniqueItems.Count);
        AddItem(uniqueItems[random]);
    }
    public void RandomEpic()
    {
        int random = Random.Range(0, epicItems.Count);
        AddItem(epicItems[random]);
    }
    public void RandomLegend()
    {
        int random = Random.Range(0, legendItems.Count);
        AddItem(legendItems[random]);
    }
    #endregion

    #region SaveandLoad
    public void LoadData(GameData _data)
    {
        foreach (KeyValuePair<string, int> pair in _data.inventory)
        {
            foreach (var item in itemDataBase)
            {
                if (item != null && item.itemID == pair.Key)
                {
                    InventoryItem itemToLoad = new InventoryItem(item);
                    itemToLoad.stackSize = pair.Value;

                    loadedItems.Add(itemToLoad);
                }
            }
        }
    }

    public void SaveData(ref GameData _data)
    {
        _data.inventory.Clear();

        foreach (KeyValuePair<ItemData, InventoryItem> pair in ItemDictionary)
        {
            _data.inventory.Add(pair.Key.itemID, pair.Value.stackSize);
        }

    }


#if UNITY_EDITOR
    [ContextMenu("Fill up item data base")]
    private void FillUpItemDataBase() => itemDataBase = new List<ItemData>(GetItemDataBase());

    private List<ItemData> GetItemDataBase()
    {
        List<ItemData> itemDataBase = new List<ItemData>();
        string[] assetNames = AssetDatabase.FindAssets("", new[] { "Assets/Data/Items" });

        foreach (string SOName in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(SOName);
            var itemData = AssetDatabase.LoadAssetAtPath<ItemData>(SOpath);
            itemDataBase.Add(itemData);
        }

        return itemDataBase;
    }
#endif

    #endregion
}
