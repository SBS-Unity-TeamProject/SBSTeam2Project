using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemTooltip : MonoBehaviour
{
    [SerializeField]private Image _icon;
    [SerializeField]private TextMeshProUGUI _itemName;
    [SerializeField]private TextMeshProUGUI _itemDescription;
    [SerializeField]private TextMeshProUGUI _itemRarity;

    public void SetTooltip(ItemData item)
    {
        _icon.sprite = item.icon;
        _itemName.text = item.itemName;
        _itemDescription.text = item.itemDescription;
        _itemRarity.text = item.itemType.ToString();
    }

    private void CleanUpTootip()
    {
        _icon = null;
        _itemName = null;
        _itemDescription = null;
        _itemRarity = null;
    }
}
