using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusEffects : MonoBehaviour
{
    //Serialize Params


    //State
    bool burning;
    int turnsBurning;
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
        turnsBurning = 0;
        burnDamage = 0;
    }

    public void Tick()
    {
        if (burning)
        {
            BurnTick();
        }
    }


    public void SetBurning(int maxTurnsBurning, int damage)
    {
        burning = true;
        turnsBurning += maxTurnsBurning;
        Debug.Log("New Turns Burning" + turnsBurning);
        burnDamage += damage;
    }


    public void BurnTick()
    {
        turnsBurning --;
        Debug.Log("Still Burning for" + turnsBurning);
        if (turnsBurning == 0)
        {
            burning = false;
            burnDamage = 0;
            Debug.Log("Not Burning anymore");
        }
        playerHealth.TakeDamage(burnDamage);
    }
}
