using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleScreenController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI turnDisplayText;
    [SerializeField] string playerTurnDisplay;
    [SerializeField] string enemyTurnDisplay;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTurnDisplayToEnemy()
    {
        turnDisplayText.text = enemyTurnDisplay;
    }
    public void ChangeTurnDisplayToPlayer()
    {
        turnDisplayText.text = playerTurnDisplay;
    }
}
