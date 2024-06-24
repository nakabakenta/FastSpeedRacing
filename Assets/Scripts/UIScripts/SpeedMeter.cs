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
        //MeterText ‚ÉVelocity ‚Ì‘å‚«‚³‚ğ‘¬Š·ZA¬”“_‘æ“ñˆÊ‚Ü‚Å•\¦‚³‚ê‚é‚æ‚¤‚É‚·‚é
        speedMeter.text = Mathf.Floor(rb.velocity.magnitude * 10) / 10 + " Km/h";
    }
}
