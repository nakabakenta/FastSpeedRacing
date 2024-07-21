using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenuButton : MonoBehaviour
{
    public void Yes()
    {
        SceneManager.LoadScene("Title");
    }
    public void No()
    {
        GameManager.returnMenuState = "No";
    }
}
