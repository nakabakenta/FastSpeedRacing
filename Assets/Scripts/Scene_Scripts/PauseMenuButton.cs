using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButton : MonoBehaviour
{
    public void BackToGame()
    {
        GameManager.pauseMenuState = "BackToGame";
    }
    public void ControlGuide()
    {
        GameManager.pauseMenuState = "ControlGuide";
    }
    public void Restart()
    {
        GameManager.pauseMenuState = "Restart";
    }

    public void RestartYes()
    {
        Time.timeScale = 1;

        if (GameManager.nowStage == "Stage01")
        {
            SceneManager.LoadScene("Stage01");
        }
        else if(GameManager.nowStage == "Stage02")
        {
            SceneManager.LoadScene("Stage02");
        }
        else if (GameManager.nowStage == "Stage03")
        {
            SceneManager.LoadScene("Stage03");
        }
        else if (GameManager.nowStage == "Stage04")
        {
            SceneManager.LoadScene("Stage04");
        }
        else if (GameManager.nowStage == "Stage05")
        {
            SceneManager.LoadScene("Stage05");
        }
    }
    public void BackToMenu()
    {
        GameManager.pauseMenuState = "BackToMenu";
    }
    public void BackToMenuYes()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StageSelect");
    }
    public void No()
    {
        GameManager.pauseMenuState = "No";
    }
}
