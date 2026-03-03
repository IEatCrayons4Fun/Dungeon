using System.Collections.Generic;
using UnityEngine;

public class ItemRespawnManager : MonoBehaviour
{
    public static ItemRespawnManager instance;
    private List<PickupBase> allItems = new List<PickupBase>();

    void Awake()
    {
        instance = this;
    }

    public void RegisterItem(PickupBase item)
    {
        allItems.Add(item);
    }

    public void RespawnAllItems()
    {
        foreach (PickupBase item in allItems)
        {
            item.Respawn();
        }
    }
}