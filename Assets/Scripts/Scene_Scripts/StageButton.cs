using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public void BackToGame()
    {
        GameManager.pauseMenuState = "BackToGame";
    }
    public void NextStage()
    {
        GameManager.stageClearMenuState = "NextStage";
    }
    public void NextStageYes()
    {
        Time.timeScale = 1;

        if (GameManager.nowStage == 1)
        {
            GameManager.nowStage = 2;
            SceneManager.LoadScene("Stage02");
        }
        else if (GameManager.nowStage == 2)
        {
            GameManager.nowStage = 3;
            SceneManager.LoadScene("Stage03");
        }
        else if (GameManager.nowStage == 3)
        {
            GameManager.nowStage = 4;
            SceneManager.LoadScene("Stage04");
        }
        else if (GameManager.nowStage == 4)
        {
            GameManager.nowStage = 5;
            SceneManager.LoadScene("Stage05");
        }
    }
    public void ControlGuide()
    {
        GameManager.pauseMenuState = "ControlGuide";
    }
    public void Restart()
    {
        if (GameManager.gameState == "PauseMenu")
        {
            GameManager.pauseMenuState = "Restart";
        }
        else if (GameManager.gameState == "Goal")
        {
            GameManager.stageClearMenuState = "Restart";
        }
    }
    public void RestartYes()
    {
        Time.timeScale = 1;

        if (GameManager.nowStage == 1)
        {
            SceneManager.LoadScene("Stage01");
        }
        else if(GameManager.nowStage == 2)
        {
            SceneManager.LoadScene("Stage02");
        }
        else if (GameManager.nowStage == 3)
        {
            SceneManager.LoadScene("Stage03");
        }
        else if (GameManager.nowStage == 4)
        {
            SceneManager.LoadScene("Stage04");
        }
        else if (GameManager.nowStage == 5)
        {
            SceneManager.LoadScene("Stage05");
        }
    }
    public void BackToMenu()
    {
        if (GameManager.gameState == "PauseMenu")
        {
            GameManager.pauseMenuState = "BackToMenu";
        }
        else if (GameManager.gameState == "Goal")
        {
            GameManager.stageClearMenuState = "BackToMenu";
        }
    }
    public void BackToMenuYes()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StageSelect");
    }
    public void No()
    {
        if(GameManager.gameState == "PauseMenu")
        {
            GameManager.pauseMenuState = "No";
        }
        else if(GameManager.gameState == "Goal")
        {
            GameManager.stageClearMenuState = "No";
        }
    }
}
