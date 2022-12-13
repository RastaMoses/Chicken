using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    public bool canClick = false;
    public int buttonNumber;


    private void OnMouseDown()
    {
        if (canClick)
        {
            GetComponent<Animator>().Play("Click");
            FindObjectOfType<Game>().AddToPlayerOrder(buttonNumber);
        }
    }

    public void PlayAnimation()
    {
        GetComponent<Animator>().Play("SimonSays");
    }
    public void PlayWinAnimation()
    {
        GetComponent<Animator>().Play("Win");
    }
}
