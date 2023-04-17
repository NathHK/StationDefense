using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public Button level1;
    public Button level2;
    public Button level3;
    public Button mainMenu;

    public AudioSource playWhenTapped;

    // Start is called before the first frame update
    void Start()
    {
        level1.onClick.AddListener(Level1);
        level2.onClick.AddListener(Level2);
        level3.onClick.AddListener(Level3);
        mainMenu.onClick.AddListener(MainMenu);

        playWhenTapped = GameObject.Find("PlayWhenTapped").GetComponent<AudioSource>();
    }

    void Level1()
    {
        playWhenTapped.Play();
        SceneManager.LoadSceneAsync("Level1");

        SceneTracker.currentScene = "Level1";
    }

    void Level2()
    {
        playWhenTapped.Play();
        SceneManager.LoadSceneAsync("Level2");

        SceneTracker.currentScene = "Level2";
    }

    void Level3()
    {
        playWhenTapped.Play();
        SceneManager.LoadSceneAsync("Level3");

        SceneTracker.currentScene = "Level3";
    }

    void MainMenu()
    {
        playWhenTapped.Play();
        SceneManager.LoadSceneAsync("StartMenu");

        SceneTracker.currentScene = "StartMenu";
    }

} //END OF CLASS
