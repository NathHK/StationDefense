using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    // the Bullet shot by this Tower
    public GameObject bulletPrefab;

    // speed at which the Tower rotates
    public float rotationSpeed = 35f;

    // delay between shots fired (in seconds)
    public float shootingDelay = 1f;

    // track when the last bullet was fired 
    private float timeOfLastShot = 0f;

    // set when an Enemy enters this Tower's collider
    public Collider currentEnemy;

    // Update is called once per frame
    void Update()
    {
        // have the Tower slowly rotate around 
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
    }

    // Shoot monsters within range of Tower's sphere collider
    void OnTriggerEnter(Collider other) 
    {
        // If it's an Enemy, shoot it!
        if(other.GetComponent<Enemy>() || other.GetComponent<Tank>()) {
            // set currentEnemy to be the one that entered range
            currentEnemy = other;
            // Has the shooting delay been met?
            if(Time.time - timeOfLastShot >= shootingDelay) {
                // Spawn a bulletPrefab
                GameObject bullet = (GameObject) Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                // And mark the time
                timeOfLastShot = Time.time;
                // Set the bullet's target 
                bullet.GetComponent<Bullet>().target = other.transform;
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }// end of OnTriggerEnter()

    // Keep shooting until Enemy leaves targeting range
    void OnTriggerStay(Collider other) 
    {
        // We want the Tower to fire at one Enemy at a time
        if(other == currentEnemy && (Time.time - timeOfLastShot >= shootingDelay)) {
            GameObject bullet = (GameObject) Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            timeOfLastShot = Time.time;
            bullet.GetComponent<Bullet>().target = other.transform;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }// end of OnTriggerStay()

}// END OF CLASS
