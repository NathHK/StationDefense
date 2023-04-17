using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 10f;
    // Target -- will be set by the Tower that fires the bullet
    public Transform target;

    void FixedUpdate() 
    {
        // Target still exists?
        if(target) {
            // make the bullet fly towards its target
            Vector3 dir = target.position - transform.position;
            GetComponent<Rigidbody>().velocity = dir.normalized * speed;
        }

        else {
            // Otherwise, DESTROY self
            Destroy(gameObject);
        }
    }// end of FixedUpdate()

    // Handles damage dealing
    void OnTriggerEnter(Collider other) 
    {
        if(gameObject.tag == "TankBullet" && other.gameObject.tag == "Tank") { // prevent Tank from damaging itself
        } else {
            Health health = other.GetComponentInChildren<Health>();
            if(health) {
                health.Decrease();
                // after damaging enemy, DESTROY self
                Destroy(gameObject);
            }
        }
    }// end of OnTriggerEnter()

}// END OF CLASS
