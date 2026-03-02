using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();
    public event Action OnInventoryChanged;

    public void AddItem(string item)
    {
        items.Add(item);
        Debug.Log(item + " added!");
        OnInventoryChanged?.Invoke();
    }

    public void RemoveItem(string item)
{
    items.Remove(item);
    Debug.Log("Removed: " + item + " | Items left: " + items.Count);
    OnInventoryChanged?.Invoke();
}

    public bool HasItem(string itemName){
        foreach (string item in items)
        {
            if (item == itemName)
            {
                return true;
            }
        }
        return false;
    }

    public void ClearInventory(){
        items.Clear();
        OnInventoryChanged?.Invoke();
        Debug.Log("Inventory cleared!");
    }
}