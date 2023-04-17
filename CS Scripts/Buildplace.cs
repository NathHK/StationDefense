using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildplace : MonoBehaviour
{
    //The tower that should be built
    public GameObject towerPrefab;

    private Vector3 buildplacePosition;
    private Vector3 surfacePosition;

    void Start() 
    {
        buildplacePosition = transform.position;
        //float radius = transform.localScale.y/2;
        float radius = gameObject.transform.lossyScale.y/2;
        if(towerPrefab.name == "BigTower")
            radius = radius + 2;
        surfacePosition = new Vector3(buildplacePosition.x, buildplacePosition.y + radius, buildplacePosition.z);
        
    }

    //Build tower after this location is clicked on
    void OnMouseUpAsButton() 
    {
        // Only let player place towers when game isn't paused
        if(!PauseMenu.gameIsPaused) {
        //Build tower on top of this Buildplace
        GameObject t = (GameObject)Instantiate(towerPrefab);
        //t.transform.position = transform.position;
        t.transform.position = new Vector3(surfacePosition.x, surfacePosition.y + 1f, surfacePosition.z);
        }
    }

}
