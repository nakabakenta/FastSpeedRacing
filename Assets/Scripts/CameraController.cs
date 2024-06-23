using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 nowCameraPos;//現在のカメラ位置
    private int nowFrontCamera;  //現在使用中のカメラ（前）
    private int nowBackCamera;   //現在使用中のカメラ（後）
    public CameraInfo cameraInfo;//車の情報

    // Start is called before the first frame update
    void Start()
    {
        nowCameraPos = cameraInfo.followObj.transform.position + cameraInfo.frontCameraPos;
        nowFrontCamera = 1;
        nowBackCamera = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //視点の切り替え
        //F1キー（前）
        if (Input.GetKeyDown(KeyCode.F1))
        {
            this.transform.localEulerAngles = new Vector3(0, 0, 0);

            if (nowFrontCamera == 1)
            {
                nowCameraPos = cameraInfo.upFrontCameraPos;
                nowFrontCamera = 2;
            }
            else if (nowFrontCamera == 2)
            {
                nowCameraPos = cameraInfo.frontCameraPos;
                nowFrontCamera = 1;
            }

            this.transform.position = nowCameraPos;
        }

        //F1キー（後）
        if (Input.GetKeyDown(KeyCode.F2))
        {
            this.transform.localEulerAngles = new Vector3(0, 180, 0);

            if (nowBackCamera == 1)
            {
                nowCameraPos = cameraInfo.upBackCameraPos;
                nowBackCamera = 2;
            }
            else if (nowBackCamera == 2)
            {
                nowCameraPos = cameraInfo.backCameraPos;
                nowBackCamera = 1;
            }
        }

        this.transform.position = cameraInfo.followObj.transform.position + nowCameraPos;
        //this.transform.RotateAround(cameraInfo.followObj.transform.position, Vector3.up, y);
    }
}

[System.Serializable]
public class CameraInfo
{
    public GameObject followObj;    //追従するゲームオブジェクト
    public Vector3 frontCameraPos;  //カメラの位置（前）
    public Vector3 backCameraPos;   //カメラの位置（後）
    public Vector3 upFrontCameraPos;//カメラの位置（上前）
    public Vector3 upBackCameraPos; //カメラの位置（上後）
}
