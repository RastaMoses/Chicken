using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] List<GameObject> buttons;
    [SerializeField] float timeBetweenButtons = 2f;
    public List<int> order;
    public List<int> playerOrder;
    int orderIndex;
    bool canClick;
    bool playerTurn;
    // Start is called before the first frame update
    void Start()
    {
        SetClickability(false);
        order = new List<int>();
        playerOrder = new List<int>();
        canClick = false;
        //Set Numbers to buttons
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<GameButton>().buttonNumber = i;
        }

        StartCoroutine(NewRound());
    }

    IEnumerator NewRound()
    {
        SetClickability(false);
        //Plays all buttons at once
        foreach (GameObject i in buttons)
        {
            i.GetComponent<GameButton>().PlayWinAnimation();
        }

        playerOrder = new List<int>();
        
        //New Button Added
        int newButton = Random.Range(0, buttons.Count);
        order.Add(newButton);

        yield return new WaitForSeconds(3);
        StartCoroutine(PlayOrder());
    }

    IEnumerator PlayOrder()
    {
        //Play each Button once
        foreach (int i in order)
        {
            buttons[i].GetComponent<GameButton>().PlayAnimation();
            yield return new WaitForSeconds(timeBetweenButtons);
        }
        SetClickability(true);
        playerTurn = true;
        orderIndex = 0;
    }

    void SetClickability(bool clickability)
    {
        foreach (GameObject i in buttons)
        {
            i.GetComponent<GameButton>().canClick = clickability;
        }
        canClick = clickability;
    }

    public void AddToPlayerOrder(int buttonNumber)
    {
        playerOrder.Add(buttonNumber);
    }

    private void Update()
    {
        if (playerTurn)
        {
            if(playerOrder.Count - 1 < orderIndex)
            {
                return;
            }
            else
            {
                if(playerOrder[orderIndex] != order[orderIndex])
                {
                    GameOver();
                }
                else
                {
                    orderIndex++;
                    if (orderIndex == order.Count)
                    {
                        playerTurn = false;
                        orderIndex = 0;
                        StartCoroutine(NewRound());
                    }
                }
            }
        }
    }


    void GameOver()
    {
        SetClickability(false);
        playerTurn = false;
        Debug.Log("GAME OVER!");
        gameOverScreen.SetActive(true);
    }
}
