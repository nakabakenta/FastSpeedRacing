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
        GameManager.controlGuideMenuState = "Null";
        GameManager.restartMenuState = "Null";
        GameManager.backToMenuState = "Null";
        GameManager.stageClearMenuState = "Null";

        stageInfo.objCountdown.SetActive(true);
        stageInfo.objGoal.SetActive(false);
        stageInfo.objPauseMenu.SetActive(false);
        stageInfo.objControlGuideMenu.SetActive(false);
        stageInfo.objRestartMenu.SetActive(false);
        stageInfo.objBackToMenu.SetActive(false);
        stageInfo.objStageClearMenu.SetActive(false);
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
        if (GameManager.countdownState == "Exist" || GameManager.countdownState == "Go" 
            && GameManager.gameState != "Goal")
        {
            PauseMenu();
        }
        if (GameManager.gameState == "Goal")
        {
            Goal();
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
    void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.pauseMenuState == "Null")
        {
            saveState = GameManager.gameState;
            GameManager.gameState = "PauseMenu";
            GameManager.pauseMenuState = "Exist";
            stageInfo.objPauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objPauseMenuFirstButtonSelect);
            Time.timeScale = 0;
        }

        if (GameManager.pauseMenuState == "BackToGame")
        {
            GameManager.gameState = saveState;
            GameManager.pauseMenuState = "Null";
            stageInfo.objPauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        if (GameManager.pauseMenuState == "ControlGuide" && GameManager.controlGuideMenuState == "Null")
        {
            GameManager.controlGuideMenuState = "Exist";
            stageInfo.objPauseMenu.SetActive(false);
            stageInfo.objControlGuideMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && GameManager.pauseMenuState == "ControlGuide"
            && GameManager.controlGuideMenuState == "Exist")
        {
            GameManager.pauseMenuState = "No";
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
            GameManager.controlGuideMenuState = "Null";
            GameManager.restartMenuState = "Null";
            GameManager.backToMenuState = "Null";
            stageInfo.objControlGuideMenu.SetActive(false);
            stageInfo.objRestartMenu.SetActive(false);
            stageInfo.objBackToMenu.SetActive(false);
            stageInfo.objPauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objPauseMenuFirstButtonSelect);
        }
    }
    void Goal()
    {
        stageInfo.objGoal.SetActive(true);

        if (GameManager.gameState == "Goal" && GameManager.stageClearMenuState == "Null")
        {
            Invoke("GoalMenu", 3.0f);
        }

        if (GameManager.stageClearMenuState == "Restart" && GameManager.restartMenuState == "Null")
        {
            GameManager.restartMenuState = "Exist";
            stageInfo.objStageClearMenu.SetActive(false);
            stageInfo.objRestartMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objRestartMenuFirstButtonSelect);
        }

        if (GameManager.stageClearMenuState == "BackToMenu" && GameManager.backToMenuState == "Null")
        {
            GameManager.backToMenuState = "Exist";
            stageInfo.objStageClearMenu.SetActive(false);
            stageInfo.objBackToMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objBackToMenuFirstButtonSelect);
        }

        if (GameManager.stageClearMenuState == "No")
        {
            GameManager.stageClearMenuState = "Exist";
            GameManager.restartMenuState = "Null";
            GameManager.backToMenuState = "Null";
            stageInfo.objRestartMenu.SetActive(false);
            stageInfo.objBackToMenu.SetActive(false);
            stageInfo.objStageClearMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objStageClearMenuFirstButtonSelect);
        }
    }
    void GoalMenu()
    {
        stageInfo.objGoal.SetActive(false);

        if (GameManager.stageClearMenuState == "Null")
        {
            GameManager.stageClearMenuState = "Exist";
            stageInfo.objStageClearMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objStageClearMenuFirstButtonSelect);
        }
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
    public GameObject objControlGuideMenu;
    public GameObject objRestartMenu;
    public GameObject objRestartMenuFirstButtonSelect;
    public GameObject objBackToMenu;
    public GameObject objBackToMenuFirstButtonSelect;
    public GameObject objStageClearMenu;
    public GameObject objStageClearMenuFirstButtonSelect;

    public TMP_Text textCountdown;
    public TMP_Text textNowTimer;
    public TMP_Text textSpeedMeter;
}