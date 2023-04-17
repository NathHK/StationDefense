using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tank : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject barrel1;
    public GameObject barrel2;

    public float chargeLength;

    public GameObject dest1;
    public GameObject dest2;

    public AudioSource chargedShot;

    public float shotStart;

    public bool instakill; // Currently set to false in Unity editor
    
    private int bulletCount = 0;

    private bool shotFired; 

    private float timeSpawned;
    void Awake() 
    {
        dest1 = GameObject.Find("dest1");
        dest2 = GameObject.Find("dest2");

        shotFired = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().destination = dest1.transform.position;
        shotStart = 0;
        timeSpawned = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        
        // DEBUG:
        if(GetComponent<NavMeshAgent>().destination == dest1.transform.position) { // this is never evaluating to true and idky
            Debug.LogWarning("Tank has stopped moving. \n Path status: " + GetComponent<NavMeshAgent>().pathStatus + "\nCurrent Agent velocity: " + GetComponent<NavMeshAgent>().velocity.ToString(), gameObject);
        }
        /*
        if(GetComponent<NavMeshAgent>().velocity == Vector3.zero) { 
            Debug.LogWarning("Tank has stopped moving. \n Path status: " + GetComponent<NavMeshAgent>().pathStatus + "\nCurrent Agent velocity: " + GetComponent<NavMeshAgent>().velocity.ToString(), gameObject);
        }
        */
        
    }

    void FixedUpdate() 
    {
        // Tank has reached dest1, the position it will fire from. Start chargedShot to indicate that the cannons are preparing to fire.
        if(GetComponent<NavMeshAgent>().remainingDistance <= 0 && Time.time - timeSpawned >= 1 && !shotFired) {
            chargedShot.Play();
            shotStart = Time.time;
            shotFired = true;
        }

        // After timelength of chargeLength, the chargedShot AudioSource simulates gunfire.
        if(shotFired && Time.time - shotStart >= chargeLength && GameObject.Find("Castle")) {
            
            if(instakill) { // Keep firing until the castle object is destroyed. ***THIS GUARENTEES THAT THE TANK WILL FIRE ENOUGH BULLETS TO KILL THE CASTLE.
                GameObject bullet1 = (GameObject) Instantiate(bulletPrefab, barrel1.transform.position, Quaternion.identity);
                GameObject bullet2 = (GameObject) Instantiate(bulletPrefab, barrel2.transform.position, Quaternion.identity);

                GameObject castle = GameObject.Find("Castle");
                bullet1.GetComponent<Bullet>().target = castle.transform;
                bullet2.GetComponent<Bullet>().target = castle.transform;
            } else if(bulletCount < 4) { // Instead of an insta-kill attack, have the tank fire two bullets from each barrel, thus dealing 4 damage. 
                GameObject bullet1 = (GameObject) Instantiate(bulletPrefab, barrel1.transform.position, Quaternion.identity);
                GameObject bullet2 = (GameObject) Instantiate(bulletPrefab, barrel2.transform.position, Quaternion.identity);

                GameObject castle = GameObject.Find("Castle");
                bullet1.GetComponent<Bullet>().target = castle.transform;
                bullet2.GetComponent<Bullet>().target = castle.transform;

                bulletCount += 2;
            }
        }

        if(shotFired && Time.time - shotStart >= chargedShot.clip.length && !chargedShot.isPlaying) {
            GetComponent<NavMeshAgent>().destination = dest2.transform.position;
            Debug.Log("Destination: " + GetComponent<NavMeshAgent>().destination + "\nCurrent position: " + GetComponent<NavMeshAgent>().transform.position + "\nCurrent Agent velocity: " + GetComponent<NavMeshAgent>().velocity.ToString() + "\nRemaining distance: " + GetComponent<NavMeshAgent>().remainingDistance, gameObject);  
        }

        if(Mathf.Abs(Vector3.Distance(GetComponent<NavMeshAgent>().transform.position, dest2.transform.position)) <= 0.025) {
            Destroy(gameObject);
        }

    } // end of FixedUpdate()
}
