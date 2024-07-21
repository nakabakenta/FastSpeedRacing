using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class Stage : MonoBehaviour
{
    private Rigidbody rb;
    private float countdown;
    private float timer;

    public string saveGameState;
    public StageInfo stageInfo;

    // Start is called before the first frame update
    void Start()
    {
        rb = stageInfo.objTargetCar.GetComponent<Rigidbody>();
        GameManager.nowScene = "Stage";
        GameManager.gameState = "Countdown";
        GameManager.countdownState = "Exist";
        GameManager.pauseMenuState = "Null";
        stageInfo.objPauseMenu.SetActive(false);
        stageInfo.objGoal.SetActive(false);
        countdown = 4;
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.countdownState == "Exist" || GameManager.countdownState == "Go" 
            && GameManager.pauseMenuState == "Null")
        {
            Countdown();
        }
        if (GameManager.gameState == "Playing" && GameManager.pauseMenuState == "Null")
        {
            Timer();
        }
        if (GameManager.gameState == "Goal")
        {
            Goal();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.nowScene == "Stage"
            && GameManager.pauseMenuState == "Null")
        {
            saveGameState = GameManager.gameState;
            GameManager.gameState = "PauseMenu";
            GameManager.pauseMenuState = "Exist";
            stageInfo.objPauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objFirstButtonSelect);
        }

        if(GameManager.pauseMenuState == "BackToGame")
        {
            GameManager.gameState = saveGameState;
            GameManager.pauseMenuState = "Null";
            stageInfo.objPauseMenu.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        stageInfo.textSpeedMeter.text = Mathf.Floor(rb.velocity.magnitude * 10) / 10 + " Km/h";
    }
    void Countdown()
    {
        countdown -= Time.deltaTime;
        int second = (int)countdown;

        if(second > 0 && GameManager.countdownState == "Exist")
        {
            stageInfo.textCountdown.text = second.ToString();
        }
        else if (second <= 0 && GameManager.countdownState == "Exist")
        {
            stageInfo.textCountdown.text = "GO!!";
            GameManager.gameState = "Playing";
            GameManager.countdownState = "Go";
        }
        else if (second <= -2 && GameManager.countdownState == "Go")
        {
            stageInfo.objCountdown.SetActive(false);
            GameManager.countdownState = "Null";
        }
    }
    void Timer()
    {
        timer += Time.deltaTime;
        int minute = (int)timer / 60;
        int second = (int)timer % 60;
        int msecond = (int)(timer * 100 % 100);
        string minText, secText, msecText;
        if (minute < 10)
        {
            minText = "0" + minute.ToString();
        }
        else
        {
            minText = minute.ToString();
        }

        if (second < 10)
        {
            secText = "0" + second.ToString();
        }
        else
        {
            secText = second.ToString();
        }

        if (msecond < 10)
        {
            msecText = "0" + msecond.ToString();
        }
        else
        {
            msecText = msecond.ToString();
        }

        stageInfo.textNowTimer.text = "NowTime : " + minText + "." + secText + "." + msecText;
    }
    void Goal()
    {
        stageInfo.objGoal.SetActive(true);
    }
}

[System.Serializable]
public class StageInfo
{
    public GameObject objTargetCar;
    public GameObject objCountdown;
    public GameObject objGoal;
    public GameObject objPauseMenu;
    public GameObject objFirstButtonSelect;
    public TMP_Text textCountdown;
    public TMP_Text textNowTimer;
    public TMP_Text textSpeedMeter;
}
