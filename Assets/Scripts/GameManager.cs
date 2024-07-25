using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string nowScene;             //現在のScene
    public static string nowStage;             //現在のStage
    public static string titleState;           //Titleの状況
    public static string stageSelectState;     //StageSelectの状況
    public static string pauseMenuState;       //PauseMenuの状況
    public static string gameState;            //Gameの状況
    public static string countdownState;       //Countdownの状況
    public static string stageClearMenuState;  //StageClearMenuの状況
    public static string nextStageMenuState;   //NextStageMenuの状況
    public static string controlGuideMenuState;//ControlGuideMenuの状況
    public static string restartMenuState;     //RestartMenuの状況
    public static string backToMenuState;      //BackToMenuの状況
    public static int[,] minute = new int[5, 10];           //Stage事のRecord(minute)
    public static int[,] second = new int[5, 10];           //Stage事のRecord(second)
    public static int[,] msecond = new int[5, 10];          //Stage事のRecord(msecond)
    public static string[,] textMinute = new string[5, 10]; //Stage事のRecord(minute)
    public static string[,] textSecond = new string[5, 10]; //Stage事のRecord(second)
    public static string[,] textMsecond = new string[5, 10];//Stage事のRecord(msecond)
}
