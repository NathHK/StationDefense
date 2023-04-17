using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    // TextMesh Component
    TextMesh tm;

    // Start is called before the first frame update
    // This is where we initialize the TextMesh
    void Start()
    {
        tm = GetComponent<TextMesh>();   
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make tm face the camera
        transform.forward = Camera.main.transform.forward;
    }

    // Get current Health (count the '-')
    public int GetCurrent() {
        return tm.text.Length;
    }

    // Decrease current Health (remove one '-')
    public void Decrease() {
        //Debug.Log("Current health = " + GetCurrent());
        if(GetCurrent() > 1) {
            tm.text = tm.text.Remove(tm.text.Length - 1); // Remove the rightmost '-'
            if(gameObject.GetComponentInParent<AudioSource>()){
                gameObject.GetComponentInParent<AudioSource>().Play();
            }
        } else { // Killing blow
            Destroy(transform.parent.gameObject);
        }
    }
}
