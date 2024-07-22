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
    private string saveState;

    public StageInfo stageInfo;

    // Start is called before the first frame update
    void Start()
    {
        rb = stageInfo.objTargetCar.GetComponent<Rigidbody>();
        GameManager.nowScene = "Stage";
        GameManager.gameState = "Countdown";
        GameManager.countdownState = "Exist";
        GameManager.pauseMenuState = "Null";
        GameManager.restartMenuState = "Null";
        GameManager.backToMenuState = "Null";
        stageInfo.objPauseMenu.SetActive(false);
        stageInfo.objRestartMenu.SetActive(false);
        stageInfo.objBackToMenu.SetActive(false);
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
            && GameManager.gameState != "Goal" && GameManager.pauseMenuState == "Null")
        {
            saveState = GameManager.gameState;
            GameManager.gameState = "PauseMenu";
            GameManager.pauseMenuState = "Exist";
            stageInfo.objPauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objPauseMenuFirstButtonSelect);
            Time.timeScale = 0;
        }

        if(GameManager.pauseMenuState == "BackToGame")
        {
            GameManager.gameState = saveState;
            GameManager.pauseMenuState = "Null";
            stageInfo.objPauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        if (GameManager.pauseMenuState == "Restart" && GameManager.restartMenuState == "Null")
        {
            GameManager.restartMenuState = "Exist";
            stageInfo.objPauseMenu.SetActive(false);
            stageInfo.objRestartMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objRestartMenuFirstButtonSelect);
        }

        if (GameManager.pauseMenuState == "BackToMenu" && GameManager.backToMenuState == "Null")
        {
            GameManager.backToMenuState = "Exist";
            stageInfo.objPauseMenu.SetActive(false);
            stageInfo.objBackToMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objBackToMenuFirstButtonSelect);
        }

        if (GameManager.pauseMenuState == "No")
        {
            GameManager.gameState = "PauseMenu";
            GameManager.pauseMenuState = "Exist";
            GameManager.restartMenuState = "Null";
            GameManager.backToMenuState = "Null";
            stageInfo.objRestartMenu.SetActive(false);
            stageInfo.objBackToMenu.SetActive(false);
            stageInfo.objPauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objPauseMenuFirstButtonSelect);
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
    public GameObject objPauseMenuFirstButtonSelect;
    public GameObject objRestartMenu;
    public GameObject objRestartMenuFirstButtonSelect;
    public GameObject objBackToMenu;
    public GameObject objBackToMenuFirstButtonSelect;

    public TMP_Text textCountdown;
    public TMP_Text textNowTimer;
    public TMP_Text textSpeedMeter;
}
