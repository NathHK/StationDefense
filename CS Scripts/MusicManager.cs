using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioSource menuMusic;
    public AudioSource gameMusic;

    public AudioSource[] sources;

    private void Awake() 
    {
        int numMusicManagers = FindObjectsOfType<MusicManager>().Length;
        if(numMusicManagers != 1)
        {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>();
        menuMusic = sources[0];
        gameMusic = sources[1];
    }

    // Update is called once per frame
    void Update()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        
        if((activeScene == SceneManager.GetSceneByName("Level1")) | (activeScene == SceneManager.GetSceneByName("Level2")) | (activeScene == SceneManager.GetSceneByName("Level3"))) {

            if(!gameMusic.isPlaying) {
                if(menuMusic.isPlaying)
                    menuMusic.Stop();
                gameMusic.Play();
            } 
        }

        else if(!menuMusic.isPlaying) { // one of the menu scenes
            if(gameMusic.isPlaying)
                gameMusic.Stop();
            menuMusic.Play();
        }
    } //end of Update()

} //END OF CLASS
