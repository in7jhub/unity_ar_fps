using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 1.0f;
    private PlacementIndicator placementIndicator;
    private Camera cam;
    public float shootRate;
    public float lastShootTime;
    public GameObject placeBaseButton;
    public GameObject basePrefab;


    private void Start()
    {
        cam = Camera.main;
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        basePrefab.SetActive(false);
    }

    public void placeBasePrefab(){
        basePrefab.SetActive(true);
        basePrefab.transform.position = placementIndicator.transform.position;
        placeBaseButton.SetActive(false);
    }
}
