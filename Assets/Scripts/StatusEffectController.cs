using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectController : MonoBehaviour
{
    //Serialize Params
    [SerializeField] ScriptableObject soBurn;



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
        
        
        burnDuration = 0;
        burnDamage = 0;

    }


    

    public void Tick()
    {
        if (burn)
        {
            soBurn.Tick();
        }
    }

    //Set Status
    public void SetBurn(int duration, int damage)
    {
        burn = true;
        burnDuration += duration;
        burnDamage += damage;

    }


    

    public void CleanseAllEffects()
    {
        //Burning
        burnDuration = 0;
        burn = false;
    }
}

