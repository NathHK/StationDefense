using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 120; //60s*2min
    public bool timerIsRunning = false;
    public Text timeText;

    //public AudioSource victory;
    public bool levelWon;
    public GameObject victoryMessage;

    private void Awake() {

        levelWon = false;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning) {

            if(timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            } else {
                timeRemaining = 0;
                timerIsRunning = false;
                LevelWon();
            }
        }

    } //end of Update()

    void DisplayTime(float timeToDisplay)
    {

        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    
    } //end of DisplayTime()

    void LevelWon()
    {
        // display end-of-level message
        victoryMessage.SetActive(true);
        
        Time.timeScale = 0;
    }

} //END OF CLASS
