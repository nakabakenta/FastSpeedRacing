using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class SpeedMeter : MonoBehaviour
{
    public GameObject objCar;
    public TMP_Text speedMeter;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = objCar.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //MeterText にVelocity の大きさを時速換算、小数点第二位まで表示されるようにする
        speedMeter.text = Mathf.Floor(rb.velocity.magnitude * 10) / 10 + " Km/h";
    }
}
