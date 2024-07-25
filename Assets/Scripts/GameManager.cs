using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string nowScene;             //���݂�Scene
    public static string nowStage;             //���݂�Stage
    public static string titleState;           //Title�̏�
    public static string stageSelectState;     //StageSelect�̏�
    public static string pauseMenuState;       //PauseMenu�̏�
    public static string gameState;            //Game�̏�
    public static string countdownState;       //Countdown�̏�
    public static string stageClearMenuState;  //StageClearMenu�̏�
    public static string nextStageMenuState;   //NextStageMenu�̏�
    public static string controlGuideMenuState;//ControlGuideMenu�̏�
    public static string restartMenuState;     //RestartMenu�̏�
    public static string backToMenuState;      //BackToMenu�̏�
    public static int[,] minute = new int[5, 10];           //Stage����Record(minute)
    public static int[,] second = new int[5, 10];           //Stage����Record(second)
    public static int[,] msecond = new int[5, 10];          //Stage����Record(msecond)
    public static string[,] textMinute = new string[5, 10]; //Stage����Record(minute)
    public static string[,] textSecond = new string[5, 10]; //Stage����Record(second)
    public static string[,] textMsecond = new string[5, 10];//Stage����Record(msecond)
}
