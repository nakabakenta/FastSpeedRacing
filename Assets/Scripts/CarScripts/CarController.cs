using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;     //Rigidbody�^�̕ϐ�
    private float accelerator;//�A�N�Z��
    private float brake;      //�u���[�L
    private float steering;   //�X�e�A�����O
    private bool useLight;    //���C�g�̏��

    public CarInfo carInfo;          //�Ԃ̏��
    public List<WheelInfo> wheelInfo;//�^�C���̏��

    // Start is called before the first frame update
    void Start()
    {
        rb = this.transform.GetComponent<Rigidbody>();
        useLight = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity.magnitude);

        //R�L�[����
        if (carInfo.useRHL && useLight == false && Input.GetKeyDown(KeyCode.L))
        {
            carInfo.RHL.localEulerAngles = new Vector3(-90, 0, 0);
            useLight = true;
        }
        else if (carInfo.useRHL && useLight == true && Input.GetKeyDown(KeyCode.L))
        {
            carInfo.RHL.localEulerAngles = new Vector3(0, 0, 0);
            useLight = false;
        }

        foreach (WheelInfo wheelInfo in wheelInfo)
        {
            wheelInfo.trLeftWheel.Rotate(wheelInfo.wcLeftWheel.rpm / 60 * 360 * Time.deltaTime, 0, 0);
            wheelInfo.trRightWheel.Rotate(wheelInfo.wcRightWheel.rpm / 60 * 360 * Time.deltaTime, 0, 0);

            if (wheelInfo.useTorque)
            {
                wheelInfo.trLeftWheel.localEulerAngles = new Vector3(wheelInfo.trLeftWheel.localEulerAngles.x, wheelInfo.wcLeftWheel.steerAngle - wheelInfo.trLeftWheel.localEulerAngles.z, wheelInfo.trLeftWheel.localEulerAngles.z);
                wheelInfo.trRightWheel.localEulerAngles = new Vector3(wheelInfo.trRightWheel.localEulerAngles.x, wheelInfo.wcRightWheel.steerAngle - wheelInfo.trRightWheel.localEulerAngles.z, wheelInfo.trRightWheel.localEulerAngles.z);
            }
        }
    }

    void FixedUpdate()
    {
        //W�L�[����
        if (Input.GetKey(KeyCode.W))
        {
            accelerator = carInfo.upTorque;

            foreach (WheelInfo wheelInfo in wheelInfo)
            {
                if (wheelInfo.useTorque)
                {
                    wheelInfo.wcLeftWheel.motorTorque = accelerator;
                    wheelInfo.wcRightWheel.motorTorque = accelerator;
                }
            }
        }
        else
        {
            foreach (WheelInfo wheelInfo in wheelInfo)
            {
                if (wheelInfo.useTorque)
                {
                    wheelInfo.wcLeftWheel.motorTorque = 0;
                    wheelInfo.wcRightWheel.motorTorque = 0;
                }
            }
        }

        //S�L�[����
        if (Input.GetKey(KeyCode.S))
        {
            brake = carInfo.downTorque;

            foreach (WheelInfo wheelInfo in wheelInfo)
            {
                if (wheelInfo.useTorque)
                {
                    wheelInfo.wcLeftWheel.brakeTorque = brake;
                    wheelInfo.wcRightWheel.brakeTorque = brake;
                }
            }
        }
        else
        {
            foreach (WheelInfo wheelInfo in wheelInfo)
            {
                if (wheelInfo.useTorque)
                {
                    wheelInfo.wcLeftWheel.brakeTorque = 0;
                    wheelInfo.wcRightWheel.brakeTorque = 0;
                }
            }
        }

        //A�L�[����
        if (Input.GetKey(KeyCode.A))
        {
            steering = carInfo.steeringAngle * -1;

            foreach (WheelInfo wheelInfo in wheelInfo)
            {
                if (wheelInfo.useSteering)
                {
                    wheelInfo.wcLeftWheel.steerAngle = steering;
                    wheelInfo.wcRightWheel.steerAngle = steering;
                }
            }
        }
        //D�L�[����
        else if (Input.GetKey(KeyCode.D))
        {
            steering = carInfo.steeringAngle;

            foreach (WheelInfo wheelInfo in wheelInfo)
            {
                if (wheelInfo.useSteering)
                {
                    wheelInfo.wcLeftWheel.steerAngle = steering;
                    wheelInfo.wcRightWheel.steerAngle = steering;
                }
            }
        }
        else
        {
            foreach (WheelInfo wheelInfo in wheelInfo)
            {
                if (wheelInfo.useSteering)
                {
                    wheelInfo.wcLeftWheel.steerAngle = 0;
                    wheelInfo.wcRightWheel.steerAngle = 0;
                }
            }
        }
    }
}

[System.Serializable]
public class CarInfo
{
    public Transform RHL;      //�g�����X�t�H�[���^�̕ϐ��i���g���N�^�u���E�w�b�h���C�g�p�j
    public float maxTorque;    //�ő�g���N
    public float upTorque;     //�㏸�g���N
    public float downTorque;   //�����g���N
    public float steeringAngle;//�X�e�A�����O�̏����l
    public bool useRHL;        //���g���N�^�u���E�w�b�h���C�g���g����
}

[System.Serializable]
public class WheelInfo
{
    public Transform trLeftWheel;
    public Transform trRightWheel;
    public WheelCollider wcLeftWheel;
    public WheelCollider wcRightWheel;
    public bool useTorque;  //�g���N�̉e�����󂯂邩
    public bool useSteering;//�n���h������̉e�����󂯂邩
}


