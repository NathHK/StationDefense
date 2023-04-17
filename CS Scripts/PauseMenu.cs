using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public Button openMenu;
    public Button closeMenu;
    public Button levelSelect;
    public Button mainMenu;
    public GameObject pauseMenuContainer;

    public AudioSource playWhenTapped;

    public static bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        openMenu.onClick.AddListener(OpenMenu);
        closeMenu.onClick.AddListener(CloseMenu);
        levelSelect.onClick.AddListener(LevelSelect);
        mainMenu.onClick.AddListener(MainMenu);
        
        if(GameObject.Find("PlayWhenTapped"))
            playWhenTapped = GameObject.Find("PlayWhenTapped").GetComponent<AudioSource>();

        gameIsPaused = false;
    }

    void OpenMenu()
    {
        playWhenTapped.Play();
        // Pause the game 
        Time.timeScale = 0;
        gameIsPaused = true;
        pauseMenuContainer.SetActive(true);
    }

    void CloseMenu()
    {
        playWhenTapped.Play();
        // Resume the game
        Time.timeScale = 1;
        gameIsPaused = false;
        pauseMenuContainer.SetActive(false);
    }

    void LevelSelect()
    {
        playWhenTapped.Play();
        Time.timeScale = 1;
        gameIsPaused = false;
        SceneManager.LoadSceneAsync("LevelSelect");
        pauseMenuContainer.SetActive(false);
        
        SceneTracker.currentScene = "LevelSelect";
    }

    void MainMenu()
    {
        playWhenTapped.Play();
        Time.timeScale = 1;
        gameIsPaused = false;
        SceneManager.LoadSceneAsync("StartMenu");
        pauseMenuContainer.SetActive(false);
        
        SceneTracker.currentScene = "StartMenu";
    }

} //END OF CLASS
