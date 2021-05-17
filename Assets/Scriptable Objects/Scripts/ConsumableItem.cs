using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Item", menuName = "Inventory System/Items/Consumable")]

public class ConsumableItem : Item
{
    [SerializeField] int consumableMaxUses;
    private void Awake()
    {
        type = ItemType.Consumable;
    }

    public int GetConsumableMaxUses()
    {
        return consumableMaxUses;
    }
}
