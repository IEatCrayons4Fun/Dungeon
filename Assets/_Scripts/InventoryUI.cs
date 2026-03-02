using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject itemSlotPrefab;
    public Transform slotContainer;

    void Start()
    {
        inventory.OnInventoryChanged += RefreshUI;
        RefreshUI();
    }

    void OnDestroy()
    {
        inventory.OnInventoryChanged -= RefreshUI;
    }

    void RefreshUI()
    {
        // Clear old slots
        foreach (Transform child in slotContainer)
            Destroy(child.gameObject);

        // Spawn a slot for each item
        foreach (string item in inventory.items)
        {
            GameObject slot = Instantiate(itemSlotPrefab, slotContainer);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item;
        }
    }
}