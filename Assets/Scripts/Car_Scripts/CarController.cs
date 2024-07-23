using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;     //Rigidbody型の変数
    private float accelerator;//アクセル
    private float brake;      //ブレーキ
    private float steering;   //ステアリング
    private bool useLight;    //ライトの状態

    public CarInfo carInfo;          //車の情報
    public List<WheelInfo> wheelInfo;//タイヤの情報

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
            //Rキー判定
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
            //Wキー判定
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
            //Sキー判定
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
            //左Shiftキー判定
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
            //右Shiftキー判定
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

            //Aキー判定
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
            //Dキー判定
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
    public Transform RHL;      //トランスフォーム型の変数（リトラクタブル・ヘッドライト用）
    public float maxTorque;    //最大トルク
    public float upTorque;     //加速トルク
    public float downTorque;   //減速トルク
    public float steeringAngle;//ステアリングの初期値
    public bool useRHL;        //リトラクタブル・ヘッドライトを使うか
}

[System.Serializable]
public class WheelInfo
{
    public Transform trLeft;
    public Transform trRight;
    public WheelCollider wcLeft;
    public WheelCollider wcRight;
    public bool useTorque;   //トルクの影響を受けるか
    public bool useSteering; //ハンドル操作の影響を受けるか
    public bool useSideBrake;//再度ブレーキの影響を受けるか
}


