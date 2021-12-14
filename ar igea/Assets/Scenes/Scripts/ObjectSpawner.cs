using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;
    bool flag;
    private void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        flag = true;
    }

    private void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            if(flag){
                GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
                flag = false;
            }
        }
    }
}
