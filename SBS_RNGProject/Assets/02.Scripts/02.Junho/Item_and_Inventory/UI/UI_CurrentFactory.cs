using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CurrentFactory : MonoBehaviour
{
    public InventoryItem item;

    [Header("UI")]
    [SerializeField] private Image itemImage;

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;

    [SerializeField] private TextMeshProUGUI itemRaraty;
    [SerializeField] private TextMeshProUGUI goldGeneration;
    [SerializeField] private TextMeshProUGUI rarity;

    public void UpdateSlot(InventoryItem _newItem)
    {
        item = _newItem;

        if (item == null)
            return;

        itemImage.color = Color.white;

        Debug.Log(this.gameObject.name);

        if (item != null)
        {
            itemImage.sprite = item.data.icon;
            itemName.text = item.data.itemName;
            itemDescription.text = item.data.itemDescription;
            itemRaraty.text = item.data.itemType.ToString();
            goldGeneration.text = "°ñµå »ý¼º·®: " + (item.data.goldGeneration /*/ SpeedUpgrade.speed*/) + "/s";
            rarity.text = item.data.itemType.ToString();
        }
    }

    public void CleanUpSlot()
    {
        item = null;

        itemImage.sprite = null;
        itemImage.color = itemImage.color = new Color(1f, 1f, 1f, 0f); ;
        itemName.text = "";
        itemDescription.text = "";
        itemRaraty.text = "";
        goldGeneration.text = "";
    }
}
