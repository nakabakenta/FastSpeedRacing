using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private int useCamera;       //�g�p���̃J����
    public CameraInfo cameraInfo;//�J�������

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
        //�J�����̐؂�ւ�
        //F5�L�[
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
    public GameObject objFront;  //�J�����i�O�j
    public GameObject objUpFront;//�J�����i��O�j
    public GameObject objBack;   //�J�����i��j
    public GameObject objUpBack; //�J�����i���j
    public GameObject objSide;   //�J�����i���j
}
