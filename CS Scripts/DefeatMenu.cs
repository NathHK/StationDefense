using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{

    public Button retry;
    public Button mainMenu;
    public GameObject defeatMessage;

    private float timeStarted;
    public AudioSource playWhenTapped;

    void Update() 
    {
        float timeSinceStart = Time.time - timeStarted;
        // If Castle has been destroyed, player has lost
        bool defeated = !GameObject.Find("Castle");
        if(defeated && timeSinceStart >= 5 && !defeatMessage.activeInHierarchy) {
            defeatMessage.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        retry.onClick.AddListener(Retry);
        mainMenu.onClick.AddListener(MainMenu);
        playWhenTapped = GameObject.Find("PlayWhenTapped").GetComponent<AudioSource>();

        timeStarted = Time.time;
        defeatMessage.SetActive(false);
    }

    void Retry()
    {
        playWhenTapped.Play();
        string current = SceneTracker.currentScene;
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(current);
        SceneTracker.currentScene = current; //added just now
    }

    void MainMenu()
    {
        playWhenTapped.Play();
        SceneTracker.currentScene = "StartMenu";
        SceneManager.LoadSceneAsync("StartMenu");
        Time.timeScale = 1;
    }

} //END OF CLASS
