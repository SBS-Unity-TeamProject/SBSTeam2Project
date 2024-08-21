using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    public static Collection Instance;

    public Dictionary<string, bool> collectedItems = new Dictionary<string, bool>();

    [Header("New Item Popup UI")]
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject gear;
    [SerializeField] private GameObject button;

    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI rarity;
    [SerializeField] private Image icon;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        InitializeItemLists();
    }

    public void MarkAsCollected(ItemData item)
    {
        if (item == null)
        {
            Debug.LogError("Item is null, cannot mark as collected.");
            return;
        }

        if (collectedItems.ContainsKey(item.itemID) && collectedItems[item.itemID] == false)
        {
            collectedItems[item.itemID] = true;
            ShowNewItemPopup(item);
        }
    }

    public bool IsCollected(ItemData item)
    {
        if (item == null)
        {
            return false;
        }

        return collectedItems.ContainsKey(item.itemID) && collectedItems[item.itemID];
    }

    private void ShowNewItemPopup(ItemData item)
    {
        StartCoroutine(GetNewItem(item));
    }

    private IEnumerator GetNewItem(ItemData item)
    {
        popup.SetActive(true);
        text.SetActive(true);
        yield return new WaitForSeconds(1);
        gear.SetActive(true);
        SetGearInfo(item);
        yield return new WaitForSeconds(2);
        button.SetActive(true);
    }

    private void SetGearInfo(ItemData item)
    {
        name.text = item.itemName;
        rarity.text = item.itemType.ToString();
        icon.sprite = item.icon;
    }

    #region Init Dictionary
    private void InitializeItemLists()
    {
#if UNITY_EDITOR
        string rarePath = "Assets/05.Data/Item/Rare";
        string uniquePath = "Assets/05.Data/Item/Unique";
        string epicPath = "Assets/05.Data/Item/Epic";
        string legendPath = "Assets/05.Data/Item/Legend";

        AddItemsToCollection(LoadItemsFromPath(rarePath));
        AddItemsToCollection(LoadItemsFromPath(uniquePath));
        AddItemsToCollection(LoadItemsFromPath(epicPath));
        AddItemsToCollection(LoadItemsFromPath(legendPath));
#endif
    }

    private void AddItemsToCollection(List<ItemData> items)
    {
        foreach (ItemData item in items)
        {
            if (item != null && !collectedItems.ContainsKey(item.itemID))
            {
                collectedItems.Add(item.itemID, false);
            }
        }
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
    #endregion
}
