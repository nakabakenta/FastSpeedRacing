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
        GameManager.returnMenuState = "Null";
        stageSelectInfo.objReturnMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.stageSelectState == "MainMenu" 
            && GameManager.returnMenuState == "Null")
        {
            GameManager.stageSelectState = "ReturnMenu";
            GameManager.returnMenuState = "Exist";
            stageSelectInfo.objReturnMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(stageSelectInfo.objButtonYes);
        }

        if(GameManager.returnMenuState == "No")
        {
            GameManager.stageSelectState = "MainMenu";
            GameManager.returnMenuState = "Null";
            stageSelectInfo.objReturnMenu.SetActive(false);
            EventSystem.current.SetSelectedGameObject(stageSelectInfo.objFirstButtonSelect);
        }
    }
}

[System.Serializable]
public class StageSelectInfo
{
    public GameObject objReturnMenu;
    public GameObject objFirstButtonSelect;
    public GameObject objButtonYes;
    public GameObject objButtonNo;
}
