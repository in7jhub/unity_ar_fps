using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private GameObject watchTower;
    public GameObject explosionFX;
    public GameObject finExplosionFX;
    public GameObject deathSound;
    public GameObject endgameSound;
    private void OnTriggerEnter(Collider other){
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        if(other.tag == "Finish"){
            Instantiate(finExplosionFX, transform.position, Quaternion.identity);
            Instantiate(endgameSound, transform.position, Quaternion.identity);
            
            GameObject.Find("BtnManager").GetComponent<BtnManager>().isGameStarted = false;
            GameObject.Find("EnemySpawnerRed").SetActive(false);
            GameObject.Find("EnemySpawnerGreen").SetActive(false);
            GameObject.Find("EnemySpawnerBlue").SetActive(false);
            GameObject.Find("EnemySpawnerYellow").SetActive(false);
            GameObject.Find("Up").SetActive(false);
            GameObject.Find("Left").SetActive(false);
            GameObject.Find("Down").SetActive(false);
            GameObject.Find("Right").SetActive(false);
            
            for(int i = 0; i < GameObject.Find("BtnManager").GetComponent<BtnManager>().isArrowVisible_LUDR.Length; i++){
                GameObject.Find("BtnManager").GetComponent<BtnManager>().isArrowVisible_LUDR[i] = false;
            }
            GameObject[] objProjectiles = GameObject.FindGameObjectsWithTag("Respawn");
            GameObject[] objEnemies = GameObject.FindGameObjectsWithTag("GameController");
            
            GameObject.Find("Watchtower").SetActive(false);
            
            foreach(GameObject obj in objProjectiles){
                Destroy(obj);
            }
            foreach(GameObject obj in objEnemies){
                obj.SetActive(false);
            }
            return;
        } else {
            Instantiate(deathSound, transform.position, Quaternion.identity);
        }
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
