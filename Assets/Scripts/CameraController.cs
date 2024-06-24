using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    private Vector3 nowCameraPos;//���݂̃J�������W
    private int nowCameraNo;     //���݂̃J�����ԍ�
    public CameraInfo cameraInfo;//�Ԃ̏��

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

        //�J�����̐؂�ւ�
        //F1�L�[
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
    public GameObject followObj;    //�Ǐ]����I�u�W�F�N�g
    public GameObject camera;       //�g���I�u�W�F�N�g�i�J�����j
    public Vector3 frontCameraPos;  //�J�����̈ʒu�i�O�j
    public Vector3 upFrontCameraPos;//�J�����̈ʒu�i��O�j
    public Vector3 backCameraPos;   //�J�����̈ʒu�i��j
    public Vector3 upBackCameraPos; //�J�����̈ʒu�i���j
    public Vector3 sideCameraPos;   //�J�����̈ʒu�i���j
}
