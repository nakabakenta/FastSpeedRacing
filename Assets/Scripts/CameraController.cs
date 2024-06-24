using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    private Vector3 nowCameraPos;//現在のカメラ座標
    private int nowCameraNo;     //現在のカメラ番号
    public CameraInfo cameraInfo;//車の情報

    // Start is called before the first frame update
    void Start()
    {
        nowCameraPos = cameraInfo.upFrontCameraPos;
        this.transform.position += nowCameraPos;
        nowCameraNo = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (nowCameraNo >= 1 && nowCameraNo <= 2)
        {
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (nowCameraNo >= 3 && nowCameraNo <= 5)
        {
            this.transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        //カメラの切り替え
        //F1キー
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (nowCameraNo == 5)
            {
                nowCameraNo = 1;
            }
            else
            {
                nowCameraNo++;
            }
        }

        if (nowCameraNo == 1)
        {
            nowCameraPos = cameraInfo.frontCameraPos;
        }
        else if (nowCameraNo == 2)
        {
            nowCameraPos = cameraInfo.upFrontCameraPos;
        }
        else if (nowCameraNo == 3)
        {
            nowCameraPos = cameraInfo.backCameraPos;
        }
        else if (nowCameraNo == 4)
        {
            nowCameraPos = cameraInfo.upBackCameraPos;
        }
        else if (nowCameraNo == 5)
        {
            nowCameraPos = cameraInfo.sideCameraPos;
        }
    }
}

[System.Serializable]
public class CameraInfo
{
    public GameObject followObj;    //追従するオブジェクト
    public GameObject camera;       //使うオブジェクト（カメラ）
    public Vector3 frontCameraPos;  //カメラの位置（前）
    public Vector3 upFrontCameraPos;//カメラの位置（上前）
    public Vector3 backCameraPos;   //カメラの位置（後）
    public Vector3 upBackCameraPos; //カメラの位置（上後）
    public Vector3 sideCameraPos;   //カメラの位置（横）
}
