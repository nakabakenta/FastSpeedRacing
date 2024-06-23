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
        rb = this.transform.GetComponent<Rigidbody>();
        useLight = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity.magnitude);

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
        //Wキー判定
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

        //Sキー判定
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

        //Aキー判定
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
        //Dキー判定
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
    public Transform RHL;      //トランスフォーム型の変数（リトラクタブル・ヘッドライト用）
    public float maxTorque;    //最大トルク
    public float upTorque;     //上昇トルク
    public float downTorque;   //減少トルク
    public float steeringAngle;//ステアリングの初期値
    public bool useRHL;        //リトラクタブル・ヘッドライトを使うか
}

[System.Serializable]
public class WheelInfo
{
    public Transform trLeftWheel;
    public Transform trRightWheel;
    public WheelCollider wcLeftWheel;
    public WheelCollider wcRightWheel;
    public bool useTorque;  //トルクの影響を受けるか
    public bool useSteering;//ハンドル操作の影響を受けるか
}


