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
    BattleScreenController battleScreenController;
    // Start is called before the first frame update
    void Start()
    {
        battleScreenController = GetComponent<BattleScreenController>();



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
    public void SwitchTurn()
    {
        if (playerTurn)
        {
            StartEnemyTurn();
        }
        else if (enemyTurn)
        {
            StartPlayerTurn();
        }
    }
    
    void StartEnemyTurn()
    {
        playerTurn = false;
        enemyTurn = true;
        battleScreenController.ChangeTurnDisplayToEnemy();
        //Status Effects
        enemyStatusController.Tick();
    }

       
    public void StartPlayerTurn()
    {
        playerTurn = true;
        enemyTurn = false;
        battleScreenController.ChangeTurnDisplayToPlayer();
        //Status Effects
        playerStatusController.Tick();
    }



}
