using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StageSelect : MonoBehaviour
{
    public StageSelectInfo stageSelectInfo;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.nowScene = "StageSelect";
        GameManager.stageSelectState = "MainMenu";
        GameManager.pauseMenuState = "Null";
        stageSelectInfo.objPauseMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.stageSelectState == "MainMenu" 
            && GameManager.pauseMenuState == "Null")
        {
            GameManager.stageSelectState = "PauseMenu";
            GameManager.pauseMenuState = "Exist";
            stageSelectInfo.objPauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageSelectInfo.objButtonYes);
        }

        if(GameManager.pauseMenuState == "No")
        {
            GameManager.stageSelectState = "MainMenu";
            GameManager.pauseMenuState = "Null";
            stageSelectInfo.objPauseMenu.SetActive(false);
            EventSystem.current.SetSelectedGameObject(stageSelectInfo.objFirstButtonSelect);
        }
    }
}

[System.Serializable]
public class StageSelectInfo
{
    public GameObject objPauseMenu;
    public GameObject objFirstButtonSelect;
    public GameObject objButtonYes;
    public GameObject objButtonNo;
}
