using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watchtower : MonoBehaviour
{
    private bool[] arrowState;
    public float lastShootTime = 0;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        arrowState = GameObject.Find("BtnManager").GetComponent<BtnManager>().isArrowVisible_LUDR;
        Vector3 temppos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 temprot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        GameObject.Find("EnemySpawnerRed").GetComponent<Transform>().position = new Vector3(temppos.x+0.021f, temppos.y+0.24f, temppos.z+1.543f);
        GameObject.Find("EnemySpawnerRed").GetComponent<Transform>().rotation = Quaternion.Euler(temprot.x, temprot.y+180f, temprot.z);
        GameObject.Find("EnemySpawnerYellow").GetComponent<Transform>().position = new Vector3(temppos.x+1.525f, temppos.y+0.24f, temppos.z);
        GameObject.Find("EnemySpawnerYellow").GetComponent<Transform>().rotation = Quaternion.Euler(temprot.x, temprot.y+270, temprot.z+0);
        GameObject.Find("EnemySpawnerGreen").GetComponent<Transform>().position = new Vector3(temppos.x-1.529f, temppos.y+0.24f, temppos.z);
        GameObject.Find("EnemySpawnerGreen").GetComponent<Transform>().rotation = Quaternion.Euler(temprot.x, temprot.y+90, temprot.z+0);
        GameObject.Find("EnemySpawnerBlue").GetComponent<Transform>().position = new Vector3(temppos.x, temppos.y+0.24f, temppos.z+-1.59f);
        GameObject.Find("EnemySpawnerBlue").GetComponent<Transform>().rotation = Quaternion.Euler(temprot.x, temprot.y, temprot.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("BtnManager").GetComponent<BtnManager>().isGameStarted){
            arrowState = GameObject.Find("BtnManager").GetComponent<BtnManager>().isArrowVisible_LUDR;
            Vector3 temppos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 temprot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            GameObject.Find("EnemySpawnerRed").GetComponent<Transform>().position = new Vector3(temppos.x+0.021f, temppos.y+0.24f, temppos.z+1.543f);
            GameObject.Find("EnemySpawnerRed").GetComponent<Transform>().rotation = Quaternion.Euler(temprot.x, temprot.y+180f, temprot.z);
            GameObject.Find("EnemySpawnerYellow").GetComponent<Transform>().position = new Vector3(temppos.x+1.525f, temppos.y+0.24f, temppos.z);
            GameObject.Find("EnemySpawnerYellow").GetComponent<Transform>().rotation = Quaternion.Euler(temprot.x, temprot.y+270, temprot.z+0);
            GameObject.Find("EnemySpawnerGreen").GetComponent<Transform>().position = new Vector3(temppos.x-1.529f, temppos.y+0.24f, temppos.z);
            GameObject.Find("EnemySpawnerGreen").GetComponent<Transform>().rotation = Quaternion.Euler(temprot.x, temprot.y+90, temprot.z+0);
            GameObject.Find("EnemySpawnerBlue").GetComponent<Transform>().position = new Vector3(temppos.x, temppos.y+0.24f, temppos.z+-1.59f);
            GameObject.Find("EnemySpawnerBlue").GetComponent<Transform>().rotation = Quaternion.Euler(temprot.x, temprot.y, temprot.z);
        }
        arrowState = GameObject.Find("BtnManager").GetComponent<BtnManager>().isArrowVisible_LUDR;
        for(int i = 0; i < arrowState.Length; i++){
            if(arrowState[i] == true){
                if(Time.time - lastShootTime > 0.1f){
                    fire(i);
                }
            }
        }
    }

    void fire(int i){
        lastShootTime = Time.time;
        GameObject proj = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 0.24f, transform.position.z), transform.rotation);
        switch(i){
            case 0:
                //l
                GameObject.Find("RightArrow").transform.localScale = new Vector3(3.5f,3.5f,3.5f);
                GameObject.Find("UpArrow").transform.localScale = new Vector3(3.5f,3.5f,3.5f);
                GameObject.Find("DownArrow").transform.localScale = new Vector3(3.5f,3.5f,3.5f);
                GameObject.Find("LeftArrow").transform.localScale = new Vector3(4.0f+Mathf.Sin(Time.time*4.0f)*1.5f,4.0f+Mathf.Sin(Time.time*4.0f)*1.5f,4.0f+Mathf.Sin(Time.time*4.0f)*1.5f);
                proj.GetComponent<Rigidbody>().velocity = new Vector3(-1.4f,0,0);
                break;
            case 1:
                //u
                GameObject.Find("RightArrow").transform.localScale = new Vector3(3.5f,3.5f,3.5f);
                GameObject.Find("LeftArrow").transform.localScale = new Vector3(3.5f,3.5f,3.5f);
                GameObject.Find("DownArrow").transform.localScale = new Vector3(3.5f,3.5f,3.5f);
                GameObject.Find("UpArrow").transform.localScale = new Vector3(4.0f+Mathf.Sin(Time.time*4.0f)*1.5f,4.0f+Mathf.Sin(Time.time*4.0f)*1.5f,4.0f+Mathf.Sin(Time.time*4.0f)*1.5f);
                proj.GetComponent<Rigidbody>().velocity = new Vector3(0,0,1.4f);
                break;
            case 2:
                //d
                GameObject.Find("RightArrow").transform.localScale = new Vector3(3.5f,3.5f,3.5f);
                GameObject.Find("UpArrow").transform.localScale = new Vector3(3.5f,3.5f,3.5f);
                GameObject.Find("LeftArrow").transform.localScale = new Vector3(3.5f,3.5f,3.5f);
                GameObject.Find("DownArrow").transform.localScale = new Vector3(4.0f+Mathf.Sin(Time.time*4.0f)*1.5f,4.0f+Mathf.Sin(Time.time*4.0f)*1.5f,4.0f+Mathf.Sin(Time.time*4.0f)*1.5f);
                proj.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-1.4f);
                break;
            case 3:
                //r
                GameObject.Find("LeftArrow").transform.localScale = new Vector3(3.5f,3.5f,3.5f);
                GameObject.Find("UpArrow").transform.localScale = new Vector3(3.5f,3.5f,3.5f);
                GameObject.Find("DownArrow").transform.localScale = new Vector3(3.5f,3.5f,3.5f);
                GameObject.Find("RightArrow").transform.localScale = new Vector3(4.0f+Mathf.Sin(Time.time*4.0f)*1.5f,4.0f+Mathf.Sin(Time.time*4.0f)*1.5f,4.0f+Mathf.Sin(Time.time*4.0f)*1.5f);
                proj.GetComponent<Rigidbody>().velocity = new Vector3(1.4f,0,0);
                break;
        }
        Destroy(proj, 5.0f);
    }
}
