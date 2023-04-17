using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public Button returnToMain;
    public AudioSource playWhenTapped;
    //public GameObject audioListener;

    // Start is called before the first frame update
    void Start()
    {
        returnToMain.onClick.AddListener(ReturnToMain);
        playWhenTapped = GameObject.Find("PlayWhenTapped").GetComponent<AudioSource>();
    }

    void ReturnToMain()
    {
        playWhenTapped.Play();
        SceneManager.LoadSceneAsync("StartMenu");//, LoadSceneMode.Additive);
        //GameObject tempListener = GameObject.Find("AudioListener");
        //SceneManager.MoveGameObjectToScene(GameObject.Find("AudioListener"), SceneManager.GetSceneByName("StartMenu"));
        //SceneManager.MoveGameObjectToScene(tempListener, SceneManager.GetSceneByName("StartMenu"));
        //audioListener.SetActive(false);
        //Destroy(playWhenTapped, 1f);
        SceneTracker.currentScene = "StartMenu";
    }

}
