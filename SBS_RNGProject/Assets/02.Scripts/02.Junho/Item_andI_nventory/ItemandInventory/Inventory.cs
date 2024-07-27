
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<InventoryItem> item;
    public Dictionary<ItemData, InventoryItem> ItemDictionary;

    [Header("UI")]
    [SerializeField] private Transform inventorySlotParent;
    private UI_ItemSlot[] inventoryItemSlot;

    [SerializeField] private ItemData testItem01;
    [SerializeField] private ItemData testItem02;

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
        item = new List<InventoryItem>();
        ItemDictionary = new Dictionary<ItemData, InventoryItem>();

        inventoryItemSlot = inventorySlotParent.GetComponentsInChildren<UI_ItemSlot>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            AddItem(testItem01);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AddItem(testItem02);
        }
    }

    private void AddItem(ItemData _item)
    {
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

    private void UpdateSlotUI()
    {
        for (int i = 0; i < inventoryItemSlot.Length; i++)
        {
            inventoryItemSlot[i].CleanUpSlot();
        }

        for (int i = 0; i < item.Count; i++)
        {
            inventoryItemSlot[i].UpdateSlot(item[i]);
        }
    }
}
