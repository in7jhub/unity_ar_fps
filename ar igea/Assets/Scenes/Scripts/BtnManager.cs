using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public GameObject mainBGM;
    public GameObject playBGM;
    public GameObject watchTower;
    public GameObject pauseMenu;
    public GameObject pauseBtn;
    public bool isPaused;
    public bool isGameStarted;
    public GameObject startBtn;
    public GameObject[] buttons;
    private bool buttonInitFlag;
    public bool[] isArrowVisible_LUDR;
    public GameObject indicator;
    public GameObject[] spawners;
    public bool BGMflag = true;
    public GameObject enemy;
    
    void Start()
    {
        isArrowVisible_LUDR = new bool[4];
        isGameStarted = false;
        isPaused = false;
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].SetActive(false);
        }
        for(int i = 0; i < isArrowVisible_LUDR.Length; i++){
            isArrowVisible_LUDR[i] = false;
        }
        buttonInitFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameStarted){
            indicator.SetActive(false);
            if(buttonInitFlag){
                for(int i = 0; i < buttons.Length; i++){
                    buttons[i].SetActive(true);
                }
                buttonInitFlag = false;
                startBtn.SetActive(false);
                watchTower.SetActive(true);
                foreach(GameObject obj in spawners){
                    obj.SetActive(true);
                }

                GameObject.Find("Up").SetActive(true);
                GameObject.Find("Down").SetActive(true);
                GameObject.Find("Right").SetActive(true);
                GameObject.Find("Left").SetActive(true);
                GameObject.Find("EnemySpawnerRed").SetActive(true);
                GameObject.Find("EnemySpawnerGreen").SetActive(true);
                GameObject.Find("EnemySpawnerBlue").SetActive(true);
                GameObject.Find("EnemySpawnerYellow").SetActive(true);
            }
            if(!BGMflag){
                mainBGM.SetActive(false);
                playBGM.SetActive(true);
                BGMflag = true;
            }
        } else {
            
            startBtn.SetActive(true);
            GameObject.Find("titleImg").transform.position = new Vector3(Screen.width/2, Screen.height/2, GameObject.Find("titleImg").transform.position.z);
            GameObject.Find("titleImg").transform.localScale = new Vector3(1.1f+Mathf.Sin(Time.time*4.0f)/4,1.1f+Mathf.Sin(Time.time*4.0f)/4,1.1f+Mathf.Sin(Time.time*4.0f)/4);
            if(BGMflag) {
                mainBGM.SetActive(true);
                playBGM.SetActive(false);
                BGMflag = false;
            }
            indicator.SetActive(true);
        }
    }
    public void gameStartBtnPress(){
        isGameStarted = true;
        buttonInitFlag = true;
    }
    public void pauseBtnPress(){
        isPaused = true;
        pauseBtn.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void tempPauseBtn(){
        isPaused = false;
        pauseBtn.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void upArrowBtnPressed(){
        init();
        isArrowVisible_LUDR[1] = true;
    }
    public void downArrowBtnPressed(){
        init();
        isArrowVisible_LUDR[2] = true;
    }
    public void leftArrowBtnPressed(){
        init();
        isArrowVisible_LUDR[0] = true;
    }
    public void rightArrowBtnPressed(){
        init();
        isArrowVisible_LUDR[3] = true;
    }

    private void init(){
        for(int i = 0; i < isArrowVisible_LUDR.Length; i++){
            isArrowVisible_LUDR[i] = false;
        }
    }
}
