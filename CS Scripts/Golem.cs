using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Golem : MonoBehaviour
{

    public GameObject[] allowedTargets;
    public GameObject[] golemsSpawned;
    private int numGolems;

    public GameObject castle;
    private bool targetingCastle;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetBool("Sprint", true);
    }

    // Update is called once per frame
    void Update()
    {
        golemsSpawned = GameObject.FindGameObjectsWithTag("Golem");
        numGolems = golemsSpawned.Length;
        /*
        if(GetComponent<NavMeshAgent>().remainingDistance <= 3) {
            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<Animator>().SetBool("Sprint", false);
            GetComponent<Animator>().SetBool("Attack", true);
        }
        */
    }

    public void FindDestination()
    {
        /*
        if(numGolems > allowedTargets.Length | allowedTargets == null) {
            GetComponent<NavMeshAgent>().destination = castle.transform.position;
            targetingCastle = true;
        } else {
            Debug.Log(numGolems);
            Transform dest = allowedTargets[numGolems].transform;
            GetComponent<NavMeshAgent>().destination = dest.position;
        }

        GetComponent<Animator>().SetBool("Sprint", true);
        */
        castle = GameObject.Find("Castle");
        GetComponent<NavMeshAgent>().destination = castle.transform.position;
        GetComponent<Animator>().SetBool("Sprint", true);

    }
}
