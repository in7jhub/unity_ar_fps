using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool isGameStarted;
    public GameObject enemy;
    private float enemySpeed = 0.3f;
    private bool tempFlag;
    public float difficulty_0_to_10 = .1f;
    private float recordedTime = 0f;
    private bool timeFlag = true;
    private float curTime = 0;
    void Start()
    {
        tempFlag = true;
        enemy.SetActive(false);
        isGameStarted = GameObject.Find("BtnManager").GetComponent<BtnManager>().isGameStarted;
    }

    // Update is called once per frame
    void Update()
    {
        isGameStarted = GameObject.Find("BtnManager").GetComponent<BtnManager>().isGameStarted;
        if(isGameStarted){
            if(timeFlag){
                difficulty_0_to_10 = .1f;
                curTime = Time.time;
                timeFlag = false;
            }
            difficulty_0_to_10 = remap(Mathf.Floor(Time.time), curTime, 60+curTime, 0, 10);
            Debug.Log(timeFlag);
            if(timer() && (Random.Range(0,10) < difficulty_0_to_10 || (difficulty_0_to_10 < 1 && Random.Range(0,5)<3))){
                shipSpawn();
            }   
            //우주선 생성 시작
            // if(/*사망 시*/false){
            //     GameObject.Find("BtnManager").GetComponent<BtnManager>().isGameStarted = false;
            // }
        }
    }

    

    void shipSpawn(){
        GameObject proj = Instantiate(enemy, transform.position, transform.rotation);
        proj.SetActive(true);
        proj.GetComponent<Rigidbody>().velocity = transform.forward * enemySpeed * (1+difficulty_0_to_10/5);
        // Destroy(proj);        
    }

    private bool timer(){
        if(Time.time - recordedTime > (14-difficulty_0_to_10)/10){
            recordedTime = Time.time;
            return true;
        }
        return false;
    }
    private static float remap(float val, float in1, float in2, float out1, float out2)  //리맵하는 함수
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
    
}
