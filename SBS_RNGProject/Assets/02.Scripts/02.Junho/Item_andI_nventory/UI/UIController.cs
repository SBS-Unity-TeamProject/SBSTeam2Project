using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button button01;
    [SerializeField] private Button button02;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Button button03;
    [SerializeField] private Button button04;

    [SerializeField] private GameObject inventory;

    private void Start()
    {
        button01.onClick.AddListener(() => Button01());
        button02.onClick.AddListener(() => Button02());
        inventoryButton.onClick.AddListener(() => InventoryButton());
        button03.onClick.AddListener(() => Button04());
        button04.onClick.AddListener(() => Button05());
    }

    private void Button01()
    {
        return;
    }

    private void Button02()
    {
        return;
    }

    private void InventoryButton()
    {
        Debug.Log("gose");

        if (inventory.activeSelf == false)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }

    private void Button04()
    {
        return;
    }

    private void Button05()
    {
        return;
    }
}
