using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //���݂�Stage
    public static int nowStage;
    //���݂�Scene
    public static string nowScene;
    //Title�̏�
    public static string titleState;
    //StageSelect�̏�
    public static string stageSelectState;
    //PauseMenu�̏�
    public static string pauseMenuState;
    //Game�̏�
    public static string gameState;
    //StageClearMenu�̏�
    public static string stageClearMenuState;
    //NextStageMenu�̏�
    public static string nextStageMenuState;
    //ControlGuideMenu�̏�
    public static string controlGuideMenuState;
    //RestartMenu�̏�
    public static string restartMenuState;
    //BackToMenu�̏�
    public static string backToMenuState;
}
