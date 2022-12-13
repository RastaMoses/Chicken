using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float maxTime;
    [SerializeField] TextMeshProUGUI text;
    float currentTime;
    float timeLeft;

    [SerializeField] float timeUntilNextScene = 3f;

    bool goalReached;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime < maxTime && !goalReached)
        {
            currentTime += Time.deltaTime;
            timeLeft = maxTime - currentTime;
        }
        else if (currentTime >= maxTime && !goalReached)
        {
            FindObjectOfType<PlayerController>().TimerEnd();
            currentTime = -2;
        }

        //Render Time
        
        if (goalReached)
        {
            text.text = timeLeft.ToString("F2") + " s\r\nGoal Reached!" ;
        }
        else
        {
            text.text = timeLeft.ToString("F2") + " s";
        }
    }

    public void StopTimer()
    {
        goalReached = true;
        StartCoroutine(WaitForNextScene());
    }

    IEnumerator WaitForNextScene()
    {
        yield return new WaitForSeconds(timeUntilNextScene);
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }
}
