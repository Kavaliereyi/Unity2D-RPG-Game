using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerItemDrop : ItemDrop
{
    [Header("Player's drop")]
    [SerializeField] private float chanceToLoseItems;
    [SerializeField] private float chanceToLoseMaterials;

    public override void GenerateDrop()
    {
        Inventory inventory = Inventory.instance;

        foreach (InventoryItem item in Inventory.instance.GetEquipmentList().ToList())
        {
            if (Random.Range(0, 100) <= chanceToLoseItems)
            {
                DropItem(item.data);
                inventory.UnEquipItem(item.data as ItemData_Equipment);
                inventory.RemoveItem(item.data as ItemData_Equipment);
            }
        }

        foreach (InventoryItem item in Inventory.instance.GetStashList().ToList())
        {
            if (Random.Range(0, 100) <= chanceToLoseMaterials)
            {
                DropItem(item.data);
                inventory.RemoveItem(item.data);
            }
        }
    }
}
