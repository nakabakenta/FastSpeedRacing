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
        rb = this.GetComponent<Rigidbody>();
        useLight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameState == "Playing" && GameManager.pauseMenuState == "Null")
        {
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
        }

        foreach (WheelInfo wheelInfo in wheelInfo)
        {
            wheelInfo.trLeft.Rotate(wheelInfo.wcLeft.rpm / 60 * 360 * Time.deltaTime, 0, 0);
            wheelInfo.trRight.Rotate(wheelInfo.wcRight.rpm / 60 * 360 * Time.deltaTime, 0, 0);

            if (wheelInfo.useTorque)
            {
                wheelInfo.trLeft.localEulerAngles = new Vector3(wheelInfo.trLeft.localEulerAngles.x, wheelInfo.wcLeft.steerAngle - wheelInfo.trLeft.localEulerAngles.z, wheelInfo.trLeft.localEulerAngles.z);
                wheelInfo.trRight.localEulerAngles = new Vector3(wheelInfo.trRight.localEulerAngles.x, wheelInfo.wcRight.steerAngle - wheelInfo.trRight.localEulerAngles.z, wheelInfo.trRight.localEulerAngles.z);
            }
        }
    }

    void FixedUpdate()
    {
        if(GameManager.gameState == "Playing" && GameManager.pauseMenuState == "Null")
        {
            //W�L�[����
            if (Input.GetKey(KeyCode.W))
            {
                accelerator = carInfo.upTorque;

                foreach (WheelInfo wheelInfo in wheelInfo)
                {
                    if (wheelInfo.useTorque)
                    {
                        wheelInfo.wcLeft.motorTorque = accelerator;
                        wheelInfo.wcRight.motorTorque = accelerator;
                    }
                }
            }
            //S�L�[����
            else if (Input.GetKey(KeyCode.S))
            {
                accelerator = carInfo.upTorque * -1;

                foreach (WheelInfo wheelInfo in wheelInfo)
                {
                    if (wheelInfo.useTorque)
                    {
                        wheelInfo.wcLeft.motorTorque = accelerator;
                        wheelInfo.wcRight.motorTorque = accelerator;
                    }
                }
            }
            else
            {
                foreach (WheelInfo wheelInfo in wheelInfo)
                {
                    if (wheelInfo.useTorque)
                    {
                        wheelInfo.wcLeft.motorTorque = 0;
                        wheelInfo.wcRight.motorTorque = 0;
                    }
                }
            }
            //��Shift�L�[����
            if (Input.GetKey(KeyCode.LeftShift))
            {
                brake = carInfo.downTorque;

                foreach (WheelInfo wheelInfo in wheelInfo)
                {
                    wheelInfo.wcLeft.brakeTorque = brake;
                    wheelInfo.wcRight.brakeTorque = brake;
                }
            }
            else
            {
                foreach (WheelInfo wheelInfo in wheelInfo)
                {
                    wheelInfo.wcLeft.brakeTorque = 0;
                    wheelInfo.wcRight.brakeTorque = 0;
                }
            }
            //�EShift�L�[����
            if (Input.GetKey(KeyCode.RightShift))
            {
                brake = carInfo.downTorque;

                foreach (WheelInfo wheelInfo in wheelInfo)
                {
                    if (wheelInfo.useSideBrake == true)
                    {
                        wheelInfo.wcLeft.brakeTorque = brake;
                        wheelInfo.wcRight.brakeTorque = brake;
                    }
                }
            }
            else
            {
                foreach (WheelInfo wheelInfo in wheelInfo)
                {
                    if (wheelInfo.useSideBrake == true)
                    {
                        wheelInfo.wcLeft.brakeTorque = 0;
                        wheelInfo.wcRight.brakeTorque = 0;
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
                        wheelInfo.wcLeft.steerAngle = steering;
                        wheelInfo.wcRight.steerAngle = steering;
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
                        wheelInfo.wcLeft.steerAngle = steering;
                        wheelInfo.wcRight.steerAngle = steering;
                    }
                }
            }
            else
            {
                foreach (WheelInfo wheelInfo in wheelInfo)
                {
                    if (wheelInfo.useSteering)
                    {
                        wheelInfo.wcLeft.steerAngle = 0;
                        wheelInfo.wcRight.steerAngle = 0;
                    }
                }
            }
        }
        else if(GameManager.gameState == "Goal")
        {
            brake = carInfo.downTorque;

            foreach (WheelInfo wheelInfo in wheelInfo)
            {
                wheelInfo.wcLeft.brakeTorque = brake;
                wheelInfo.wcRight.brakeTorque = brake;
            }
        }
    }
}

[System.Serializable]
public class CarInfo
{
    public Transform RHL;      //�g�����X�t�H�[���^�̕ϐ��i���g���N�^�u���E�w�b�h���C�g�p�j
    public float maxTorque;    //�ő�g���N
    public float upTorque;     //�����g���N
    public float downTorque;   //�����g���N
    public float steeringAngle;//�X�e�A�����O�̏����l
    public bool useRHL;        //���g���N�^�u���E�w�b�h���C�g���g����
}

[System.Serializable]
public class WheelInfo
{
    public Transform trLeft;
    public Transform trRight;
    public WheelCollider wcLeft;
    public WheelCollider wcRight;
    public bool useTorque;   //�g���N�̉e�����󂯂邩
    public bool useSteering; //�n���h������̉e�����󂯂邩
    public bool useSideBrake;//�ēx�u���[�L�̉e�����󂯂邩
}


