using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectController : MonoBehaviour
{
    //Serialize Params
    



    //State

    //SE bools
    bool burn;
    //SE Durations
    int burnDuration;
    //SE Saved Vars
    int burnDamage;
    
    
    //Cached Comp
    Battle battle;
    PlayerHealth playerHealth;

    private void Awake()
    {
        battle = FindObjectOfType<Battle>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        //Set States to 0
        burnDuration = 0;
        burnDamage = 0;
    }
    public void Tick()
    {
        if (burn)
        {
            BurnTick();
        }
    }

    #region Set Effects
    //Set Status
    public void SetBurn(int duration, int damage)
    {
        burn = true;
        burnDuration += duration;
        burnDamage += damage;
    }
    #endregion

    #region Tick Effects

    private void BurnTick()
    {
        playerHealth.TakeDamage(burnDamage);
        burnDuration--;
        if (burnDuration <= 0)
        {
            burn = false;
            burnDamage = 0;
        }
    }

    #endregion



    public void CleanseAllEffects()
    {
        //Burning
        burnDuration = 0;
        burn = false;
    }



}

