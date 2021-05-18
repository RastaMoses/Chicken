using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //Serialize params
    [SerializeField] ConsumableItem attackItem;

    //State
    
    //cached comps
    Health enemyHealth;
    StatusEffectController enemyStatusController;
    GameObject enemy;
    


    private void Start()
    {
        //Find Health Objects and check if they are Players through Tag
        Health[] healths = FindObjectsOfType<Health>();
        foreach (Health i in healths)
        {
            //if you are not a player yourself, make the player your enemy
            if (!gameObject.CompareTag("Player"))
            {
                if (i.gameObject.CompareTag("Player"))
                {
                    enemyHealth = i;
                }
            }
            else
            {
                Debug.LogError("You need to be able to select a Target...somehow");
            }
            
        }
        enemy = enemyHealth.gameObject;
        enemyStatusController = enemy.GetComponent<StatusEffectController>();
        
    }

    public void UseItem()
    {
        var itemEffects = attackItem.GetEffects();
        StatusEffectController targetEffectController = enemyStatusController;
        Health targetHealth = enemyHealth;
        //Determine Target
        if (attackItem.GetItemTargetSelf())
        {
            targetEffectController = GetComponent<StatusEffectController>();
            targetHealth = GetComponent<Health>();
        }
        if (!attackItem.GetItemTargetSelf())
        {
            targetEffectController = enemyStatusController;
            targetHealth = enemyHealth;
        }

        //Damage
        DealDamage(attackItem.GetItemDamage(), targetHealth);

        //Effects
        if (attackItem.GetEffectsCount() > 0)
        {
            for (int i = 0; i < attackItem.GetEffectsCount(); i++)
            {
                if (itemEffects[i] == Effect.Burn)
                {
                    Burn(attackItem.GetEffectDurations()[i], attackItem.GetEffectPowers()[i], targetEffectController);
                }
            }
        }
        
    }

    private void DealDamage(int damage, Health target)
    {
        target.TakeDamage(damage);
    }

    #region Status Effects

    //Status Effect Set

    private void Burn(int burnDuration, int burnPower, StatusEffectController target)
    {
        target.SetBurn(burnDuration, burnPower);

    }

    #endregion
}
