using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    //Serialize params
    [SerializeField] int damage;
    [SerializeField] int burnDamage;
    [SerializeField] int burnDuration;
    [SerializeField] StatusEffectController playerStatusEffects;

    //State

    //cached comps
    PlayerHealth playerHealth;
    


    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        
    }


    public void DealDamage()
    {
        playerHealth.TakeDamage(damage);
    }

    public void FireAttack()
    {
        playerStatusEffects.SetBurn(burnDuration, burnDamage);

    }
}
