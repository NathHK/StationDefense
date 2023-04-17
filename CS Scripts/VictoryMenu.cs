using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{

    public Button nextLevel;
    public Button mainMenu;

    public AudioSource playWhenTapped;

    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        nextLevel.onClick.AddListener(NextLevel);
        mainMenu.onClick.AddListener(MainMenu);

        playWhenTapped = GameObject.Find("PlayWhenTapped").GetComponent<AudioSource>();
    }

    void NextLevel()
    {
        playWhenTapped.Play();
        /*
        // Which scene is currently loaded?
        if(SceneManager.GetSceneByName("Level1").isLoaded)
            nextScene = "Level2";
        else if(SceneManager.GetSceneByName("Level2").isLoaded)
            nextScene = "Level3";
        else if(SceneManager.GetSceneByName("Level3").isLoaded)
            nextScene = "Level1";
        // Load the next level
        SceneManager.LoadSceneAsync(nextScene);
        */

        // Which level is currently being played?
        string current = SceneTracker.currentScene;
        // Which level is next?
        if(current == "Level1")
            nextScene = "Level2";
        else if(current == "Level2")
            nextScene = "Level3";
        else if(current == "Level3")
            nextScene = "Level1";
        
        // Load the next level and update SceneTracker
        SceneTracker.currentScene = nextScene;
        SceneManager.LoadSceneAsync(nextScene);
        
        Time.timeScale = 1;
    }

    void MainMenu()
    {
        playWhenTapped.Play();
        SceneManager.LoadSceneAsync("StartMenu");
        SceneTracker.currentScene = "StartMenu";

        Time.timeScale = 1;
    }

} //END OF CLASS
