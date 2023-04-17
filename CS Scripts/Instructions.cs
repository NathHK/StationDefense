using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{

    public AudioSource playWhenTapped;
    public Button mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.onClick.AddListener(MainMenu);
        //DontDestroyOnLoad(playWhenTapped);
        playWhenTapped = GameObject.Find("PlayWhenTapped").GetComponent<AudioSource>();
    }

    void MainMenu()
    {
        playWhenTapped.Play();
        SceneManager.LoadSceneAsync("StartMenu");

        SceneTracker.currentScene = "StartMenu";
    }

}
