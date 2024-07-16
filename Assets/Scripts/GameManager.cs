using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string GameState = "Title";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && GameState == "Title")
        {
            SceneManager.LoadScene("StageSelect");
            GameState = "StageSelect";
        }
    }
}
