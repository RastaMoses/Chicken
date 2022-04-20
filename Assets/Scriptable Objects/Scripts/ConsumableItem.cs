using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Consumable Item", menuName = "Inventory System/Items/Consumable")]

public class ConsumableItem : Item
{
    public ConsumableType consumableType;


    [Header("Inventory")]
    [SerializeField] int consumableMaxUses;

    [Header("Damage/Duration")]
    [SerializeField] bool targetSelf;
    [SerializeField] int damage;
    

    [Header("Effects")]
    [SerializeField] Effect[] effects;
    [SerializeField] int[] effectDurations;
    [SerializeField] int[] effectPowers;

    #region Get Functions
    private void Awake()
    {
        type = ItemType.Consumable;
        
    }

    public int GetConsumableMaxUses()
    {
        return consumableMaxUses;
    }

    public int GetEffectsCount()
    {
        return effects.Length;
    }

    public bool GetItemTargetSelf()
    {
        return targetSelf;
    }

    public int GetItemDamage()
    {
        return damage;
    }

    public Effect[] GetEffects()
    {
        return effects;
    }

    public int[] GetEffectDurations()
    {
        return effectDurations;
    }

    public int[] GetEffectPowers()
    {
        return effectPowers;
    }

    #endregion
}
