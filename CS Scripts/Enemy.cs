using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Navigate to the Castle
        GameObject castle = GameObject.Find("Castle");
        if(castle) {
            GetComponent<NavMeshAgent>().destination = castle.transform.position;
        }
    } // end of Start()

    // Currently, damage is done to Castle when enemy walks into it.
    void OnTriggerEnter(Collider other) {
        // Did it collide with the Castle?
        if(other.name == "Castle") {
            other.GetComponentInChildren<Health>().Decrease();
            // Destroy this enemy 
            Destroy(gameObject);
        }
    } // end of OnTriggerEnter

} // END OF CLASS
