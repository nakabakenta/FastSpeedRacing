using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.stageSelectState == "MainMenu")
        {
            button.interactable = true;
        }
        else if(GameManager.stageSelectState == "PauseMenu")
        {
            button.interactable = false;
        }
    }
    public void LoadStage01()
    {
        GameManager.nowStage = 1;
        SceneManager.LoadScene("Stage01");
    }
    public void LoadStage02()
    {
        GameManager.nowStage = 2;
        SceneManager.LoadScene("Stage02");
    }
    public void LoadStage03()
    {
        GameManager.nowStage = 3;
        SceneManager.LoadScene("Stage03");
    }
    public void LoadStage04()
    {
        GameManager.nowStage = 4;
        SceneManager.LoadScene("Stage04");
    }
    public void LoadStage05()
    {
        GameManager.nowStage = 5;
        SceneManager.LoadScene("Stage05");
    }
}
