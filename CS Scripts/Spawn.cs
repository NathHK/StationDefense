using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    // The Enemy prefab that should be spawned
    public GameObject enemyPrefab;
    // Spawn delay (in seconds)
    public float interval = 3;

    GameObject castle;

    // Start is called before the first frame update
    void Start()
    {
        castle = GameObject.Find("Castle");
        // Spawn enemies along given time interval
        InvokeRepeating("SpawnNext", interval, interval);
    } // end of Start()

    // Instantiate an enemy
    void SpawnNext() {
        if(castle)
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    } // end of SpawnNext()

} // END OF CLASS 
