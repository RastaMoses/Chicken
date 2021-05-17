using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    //Serialize Params
    [SerializeField] StatusEffectController playerStatus;
    [SerializeField] StatusEffectController enemyStatus;

    public bool playerFirst;
    //State
    bool playerTurn;
    bool enemyTurn;


    //Cached comp

    // Start is called before the first frame update
    void Start()
    {
        //Cache Comps
       
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
    }

       
    public void StartPlayerTurn()
    {
        playerTurn = true;
        enemyTurn = false;
        //Status Effects
        playerStatus.Tick();
    }



}
