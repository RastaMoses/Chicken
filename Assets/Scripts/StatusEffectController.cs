using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectController : MonoBehaviour
{
    //Serialize Params
    



    //State

    // bool
    bool burn;
    // Durations
    int burnDuration;
    // Power
    int burnPower;
    
    
    //Cached Comp
    Battle battle;
    Health health;

    private void Awake()
    {
        battle = FindObjectOfType<Battle>();
        health = GetComponent<Health>();
    }

    private void Start()
    {
        //Set States to 0
        burnDuration = 0;
        burnPower = 0;
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
    public void SetBurn(int duration, int power)
    {
        burn = true;
        burnDuration += duration;
        Debug.Log("Burn Duration on " + gameObject.name + " is " + burnDuration);
        burnPower += power;
        Debug.Log("Burn Power on " + gameObject.name + " is " + burnPower);
    }
    #endregion

    #region Tick Effects

    private void BurnTick()
    {
        health.TakeDamage(burnPower);
        burnDuration--;
        Debug.Log("Burn Duration on " + gameObject.name + " is " + burnDuration);
        if (burnDuration <= 0)
        {
            burn = false;
            burnPower = 0;
            Debug.Log("Burn Power on " + gameObject.name + " is " + burnPower);
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

