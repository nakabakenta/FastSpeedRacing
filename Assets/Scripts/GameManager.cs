using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string nowScene;             //Œ»İ‚ÌScene
    public static string nowStage;             //Œ»İ‚ÌStage
    public static string titleState;           //Title‚Ìó‹µ
    public static string stageSelectState;     //StageSelect‚Ìó‹µ
    public static string pauseMenuState;       //PauseMenu‚Ìó‹µ
    public static string gameState;            //Game‚Ìó‹µ
    public static string countdownState;       //Countdown‚Ìó‹µ
    public static string stageClearMenuState;  //StageClearMenu‚Ìó‹µ
    public static string nextStageMenuState;   //NextStageMenu‚Ìó‹µ
    public static string controlGuideMenuState;//ControlGuideMenu‚Ìó‹µ
    public static string restartMenuState;     //RestartMenu‚Ìó‹µ
    public static string backToMenuState;      //BackToMenu‚Ìó‹µ
    public static int[,] minute = new int[5, 10];           //Stage–‚ÌRecord(minute)
    public static int[,] second = new int[5, 10];           //Stage–‚ÌRecord(second)
    public static int[,] msecond = new int[5, 10];          //Stage–‚ÌRecord(msecond)
    public static string[,] textMinute = new string[5, 10]; //Stage–‚ÌRecord(minute)
    public static string[,] textSecond = new string[5, 10]; //Stage–‚ÌRecord(second)
    public static string[,] textMsecond = new string[5, 10];//Stage–‚ÌRecord(msecond)
}
