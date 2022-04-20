using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Serialize Params


    //State
    bool enemyTurn;

    //Cached Components
    Battle battle;

    // Start is called before the first frame update
    void Awake()
    {
        enemyTurn = false;
        battle = FindObjectOfType<Battle>();
    }

    
}
