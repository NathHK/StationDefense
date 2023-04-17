using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public Button startGame;
    public Button continueGame;
    public Button instructions;
    public Button options;
    public Button exit;

    public AudioSource playWhenTapped;

    public GameObject bgMusicManager;
    
    //public GameObject audioListener;


    // Start is called before the first frame update
    void Start()
    {
        startGame.onClick.AddListener(StartGame);
        continueGame.onClick.AddListener(ContinueGame);
        instructions.onClick.AddListener(Instructions);
        options.onClick.AddListener(Options);
        exit.onClick.AddListener(Exit);

        playWhenTapped.playOnAwake = false;
        DontDestroyOnLoad(playWhenTapped);
        //DontDestroyOnLoad(bgMusicManager);
    }

    void StartGame()
    {
        playWhenTapped.Play();
        SceneManager.LoadScene("Level1");
        //Destroy(playWhenTapped);

        //SceneManager.UnloadSceneAsync("Options");
        //SceneManager.UnloadSceneAsync("StartMenu");

        SceneTracker.currentScene = "Level1";
    }

    void ContinueGame()
    {
        playWhenTapped.Play();
        SceneManager.LoadSceneAsync("LevelSelect");

        SceneTracker.currentScene = "LevelSelect";
    }

    void Instructions()
    {
        playWhenTapped.Play();
        SceneManager.LoadSceneAsync("Instructions");

        SceneTracker.currentScene = "Instructions";
    }

    void Options()
    {
        playWhenTapped.Play();
        SceneManager.LoadSceneAsync("Options");//, LoadSceneMode.Additive);
        //GameObject tempListener = audioListener;
        //SceneManager.MoveGameObjectToScene(tempListener, SceneManager.GetSceneByName("Options"));
        //Destroy(audioListener);
        //audioListener.SetActive(false);

        SceneTracker.currentScene = "Options";
    }

    void Exit() 
    {
        playWhenTapped.Play();
        Application.Quit();
    }
}
