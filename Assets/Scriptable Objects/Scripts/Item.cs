using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Consumable,
    Equipment
}
public abstract class Item : ScriptableObject
{
    [HideInInspector] public ItemType type;
    [SerializeField] Sprite icon;
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    

    public string GetItemName()
    {
        return itemName;
    }



}
