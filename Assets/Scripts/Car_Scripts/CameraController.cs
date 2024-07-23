using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private int useCamera;       //使用中のカメラ
    public CameraInfo cameraInfo;//カメラ情報

    // Start is called before the first frame update
    void Start()
    {
        useCamera = 1;
        cameraInfo.objUpFront.SetActive(false);
        cameraInfo.objBack.SetActive(false);
        cameraInfo.objUpBack.SetActive(false);
        cameraInfo.objSide.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの切り替え
        //F5キー
        if (Input.GetKeyDown(KeyCode.F5) && GameManager.gameState != "Goal")
        {
            if (useCamera == 5)
            {
                useCamera = 1;
            }
            else
            {
                useCamera++;
            }
        }

        if (useCamera == 1)
        {
            cameraInfo.objFront.SetActive(true);
            cameraInfo.objUpFront.SetActive(false);
            cameraInfo.objBack.SetActive(false);
            cameraInfo.objUpBack.SetActive(false);
            cameraInfo.objSide.SetActive(false);
        }
        else if (useCamera == 2)
        {
            cameraInfo.objFront.SetActive(false);
            cameraInfo.objUpFront.SetActive(true);
            cameraInfo.objBack.SetActive(false);
            cameraInfo.objUpBack.SetActive(false);
            cameraInfo.objSide.SetActive(false);
        }
        else if (useCamera == 3)
        {
            cameraInfo.objFront.SetActive(false);
            cameraInfo.objUpFront.SetActive(false);
            cameraInfo.objBack.SetActive(true);
            cameraInfo.objUpBack.SetActive(false);
            cameraInfo.objSide.SetActive(false);
        }
        else if (useCamera == 4)
        {
            cameraInfo.objFront.SetActive(false);
            cameraInfo.objUpFront.SetActive(false);
            cameraInfo.objBack.SetActive(false);
            cameraInfo.objUpBack.SetActive(true);
            cameraInfo.objSide.SetActive(false);
        }
        else if (useCamera == 5)
        {
            cameraInfo.objFront.SetActive(false);
            cameraInfo.objUpFront.SetActive(false);
            cameraInfo.objBack.SetActive(false);
            cameraInfo.objUpBack.SetActive(false);
            cameraInfo.objSide.SetActive(true);
        }
    }
}

[System.Serializable]
public class CameraInfo
{
    public GameObject objFront;  //カメラ（前）
    public GameObject objUpFront;//カメラ（上前）
    public GameObject objBack;   //カメラ（後）
    public GameObject objUpBack; //カメラ（上後）
    public GameObject objSide;   //カメラ（横）
}
