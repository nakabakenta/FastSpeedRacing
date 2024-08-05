using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class Stage : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
    private float countdown;
    private float timer;
    private string textMinute, textSecond, textMsecond;
    private string countdownState;
    private string saveState;
    public static int minute, second, msecond;
    public static bool setRanking;
    public StageInfo stageInfo;

    // Start is called before the first frame update
    void Start()
    {
        rb = stageInfo.objTargetCar.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
        countdownState = "Exist";
        setRanking = false;
        GameManager.nowScene = "Stage";
        GameManager.gameState = "Countdown";
        GameManager.pauseMenuState = "Null";
        GameManager.stageClearMenuState = "Null";
        GameManager.nextStageMenuState = "Null";
        GameManager.controlGuideMenuState = "Null";
        GameManager.restartMenuState = "Null";
        GameManager.backToMenuState = "Null";
        stageInfo.objNowState.SetActive(true);
        stageInfo.objPauseMenu.SetActive(false);
        stageInfo.objStageClearMenu.SetActive(false);
        stageInfo.objNextStageMenu.SetActive(false);
        stageInfo.objControlGuideMenu.SetActive(false);
        stageInfo.objRestartMenu.SetActive(false);
        stageInfo.objBackToMenu.SetActive(false);
        stageInfo.textTopRecord.text = "TopRecord : " + RankingManager.textMinute[GameManager.nowStage - 1, 0] + "." + RankingManager.textSecond[GameManager.nowStage - 1, 0] + "." + RankingManager.textMsecond[GameManager.nowStage - 1, 0];
        countdown = 4;
        StartCoroutine("StartSound");
    }
    // Update is called once per frame
    void Update()
    {
        if (countdownState == "Exist")
        {
            Countdown();
        }
        if (GameManager.gameState == "Playing")
        {
            Timer();
        }
        if (countdownState == "Exist" || countdownState == "Null"
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
        stageInfo.textSpeedMeter.text = Mathf.Floor(rb.velocity.magnitude * 3.0f * 10) / 10 + " Km/h";
    }
    void Countdown()
    {
        countdown -= Time.deltaTime;
        second = (int)countdown;

        if (second > 0 && countdownState == "Exist")
        {
            stageInfo.textNowState.text = second.ToString();
        }
        else if (second <= -2 && countdownState == "Exist")
        {
            stageInfo.objNowState.SetActive(false);
            countdownState = "Null";
        }
        else if (second <= 0 && countdownState == "Exist" && GameManager.gameState != "PauseMenu")
        {
            stageInfo.textNowState.text = "GO!!";
            GameManager.gameState = "Playing";
        }
    }
    IEnumerator StartSound()
    {
        for (int i = 0; i < 3; i++)
        {
            audioSource.PlayOneShot(stageInfo.countdown);
            yield return new WaitForSeconds(1);
        }
        audioSource.PlayOneShot(stageInfo.start);
    }
    void Timer()
    {
        timer += Time.deltaTime;
        minute = (int)timer / 60;
        second = (int)timer % 60;
        msecond = (int)(timer * 100 % 100);
        //•ª
        if (minute < 10)
        {
            textMinute = "0" + minute.ToString();
        }
        else
        {
            textMinute = minute.ToString();
        }
        //•b
        if (second < 10)
        {
            textSecond = "0" + second.ToString();
        }
        else
        {
            textSecond = second.ToString();
        }
        //ƒ~ƒŠ•b
        if (msecond < 10)
        {
            textMsecond = "0" + msecond.ToString();
        }
        else
        {
            textMsecond = msecond.ToString();
        }

        stageInfo.textNowRecord.text = "NowTime : " + textMinute + "." + textSecond + "." + textMsecond;
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
        stageInfo.textClearRecord.text = "ClearRecord : " + textMinute + "." + textSecond + "." + textMsecond;

        if (GameManager.gameState == "Goal" && GameManager.stageClearMenuState == "Null")
        {
            stageInfo.objNowRecord.SetActive(false);
            stageInfo.objTopRecord.SetActive(false);
            stageInfo.objSpeedMeter.SetActive(false);
            stageInfo.objNowState.SetActive(true);
            stageInfo.textNowState.text = "GOAL!!";
            Invoke("GoalMenu", 3.0f);
        }

        if (GameManager.stageClearMenuState == "NextStage" && GameManager.nextStageMenuState == "Null")
        {
            GameManager.nextStageMenuState = "Exist";
            stageInfo.objStageClearMenu.SetActive(false);
            stageInfo.objNextStageMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objNextStageMenuFirstButtonSelect);
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
            GameManager.nextStageMenuState = "Null";
            GameManager.restartMenuState = "Null";
            GameManager.backToMenuState = "Null";
            GameManager.stageClearMenuState = "Exist";
            stageInfo.objNextStageMenu.SetActive(false);
            stageInfo.objRestartMenu.SetActive(false);
            stageInfo.objBackToMenu.SetActive(false);
            stageInfo.objStageClearMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageInfo.objStageClearMenuFirstButtonSelect);
        }
    }
    void GoalMenu()
    {
        stageInfo.objNowState.SetActive(false);

        if (GameManager.stageClearMenuState == "Null")
        {
            setRanking = true;
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
    public GameObject objNowState;
    public GameObject objNowRecord;
    public GameObject objTopRecord;
    public GameObject objSpeedMeter;
    public GameObject objPauseMenu;
    public GameObject objPauseMenuFirstButtonSelect;
    public GameObject objStageClearMenu;
    public GameObject objStageClearMenuFirstButtonSelect;
    public GameObject objNextStageMenu;
    public GameObject objNextStageMenuFirstButtonSelect;
    public GameObject objControlGuideMenu;
    public GameObject objRestartMenu;
    public GameObject objRestartMenuFirstButtonSelect;
    public GameObject objBackToMenu;
    public GameObject objBackToMenuFirstButtonSelect;
    public TMP_Text textNowState;
    public TMP_Text textNowRecord;
    public TMP_Text textTopRecord;
    public TMP_Text textSpeedMeter;
    public TMP_Text textClearRecord;
    public AudioClip countdown;
    public AudioClip start;
}