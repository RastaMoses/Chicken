using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    //Serialize Params
    StatusEffectController playerStatusController;
    StatusEffectController enemyStatusController;

    public bool playerFirst;
    //State
    bool playerTurn;
    bool enemyTurn;


    //Cached comp

    // Start is called before the first frame update
    void Start()
    {
        //Find StatusEffectController Objects and check if they are Players through Tag and assign
        StatusEffectController[] statusControllers = FindObjectsOfType<StatusEffectController>();
        foreach (StatusEffectController i in statusControllers)
        {
            if (i.gameObject.CompareTag("Player"))
            {
                playerStatusController = i;
            }
            else
            {
                enemyStatusController = i;
            }

        }

        if (playerFirst)
        {
            StartPlayerTurn();

        }
        else
        {
            StartEnemyTurn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void StartEnemyTurn()
    {
        playerTurn = false;
        enemyTurn = true;
        //Status Effects
        enemyStatusController.Tick();
    }

       
    public void StartPlayerTurn()
    {
        playerTurn = true;
        enemyTurn = false;
        //Status Effects
        playerStatusController.Tick();
    }



}
