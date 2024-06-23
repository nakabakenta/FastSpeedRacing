using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 nowCameraPos;//���݂̃J�����ʒu
    private int nowFrontCamera;  //���ݎg�p���̃J�����i�O�j
    private int nowBackCamera;   //���ݎg�p���̃J�����i��j
    public CameraInfo cameraInfo;//�Ԃ̏��

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
        //���_�̐؂�ւ�
        //F1�L�[�i�O�j
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

        //F1�L�[�i��j
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
    public GameObject followObj;    //�Ǐ]����Q�[���I�u�W�F�N�g
    public Vector3 frontCameraPos;  //�J�����̈ʒu�i�O�j
    public Vector3 backCameraPos;   //�J�����̈ʒu�i��j
    public Vector3 upFrontCameraPos;//�J�����̈ʒu�i��O�j
    public Vector3 upBackCameraPos; //�J�����̈ʒu�i���j
}
