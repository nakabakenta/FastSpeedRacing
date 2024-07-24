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
        SceneManager.LoadScene("Stage01");
        GameManager.nowStage = "Stage01";
    }
    public void LoadStage02()
    {
        SceneManager.LoadScene("Stage02");
        GameManager.nowStage = "Stage02";
    }
    public void LoadStage03()
    {
        SceneManager.LoadScene("Stage03");
        GameManager.nowStage = "Stage03";
    }
    public void LoadStage04()
    {
        SceneManager.LoadScene("Stage04");
        GameManager.nowStage = "Stage04";
    }
    public void LoadStage05()
    {
        SceneManager.LoadScene("Stage05");
        GameManager.nowStage = "Stage05";
    }
}
