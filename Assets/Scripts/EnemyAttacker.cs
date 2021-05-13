using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    //Serialize params
    [SerializeField] int damage;
    [SerializeField] int burnDamage;
    [SerializeField] int burnDuration;

    //State

    //cached comps
    PlayerHealth playerHealth;
    PlayerStatusEffects playerStatusEffects;


    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerStatusEffects = FindObjectOfType<PlayerStatusEffects>();
    }


    public void DealDamage()
    {
        playerHealth.TakeDamage(damage);
    }

    public void FireAttack()
    {
        playerStatusEffects.SetBurning(burnDuration, burnDamage);

    }
}
