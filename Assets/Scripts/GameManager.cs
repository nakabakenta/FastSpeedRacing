using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string nowScene;             //現在のシーン
    public static string nowStage;             //現在のステージ
    public static string titleState;           //タイトルの状況
    public static string stageSelectState;     //ステージセレクトの状況
    public static string pauseMenuState;       //ポーズメニューの状況
    public static string gameState;            //ゲームの状況
    public static string countdownState;       //カウントダウンの状況
    public static string stageClearMenuState;  //ステージクリアメニューの状況
    public static string nextStageMenuState;   //NextStageMenuの状況
    public static string controlGuideMenuState;//ControlGuideMenuの状況
    public static string restartMenuState;     //リスタートメニューの状況
    public static string backToMenuState;      //ステージセレクトに戻るメニューの状況
}
