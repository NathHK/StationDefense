using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Metalon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set boolean to play the walking animation
        gameObject.GetComponent<Animator>().SetBool("Run Forward", true);
    }

    // Update is called once per frame
    void Update()
    {
        // Once Castle is reached, stop playing the walking animation
        //if(gameObject.GetComponent<NavMeshAgent>().remainingDistance == 0)
            //gameObject.GetComponent<Animator>().SetBool("Run Forward", false);

    }
}
