using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class GameScene : MonoBehaviour
{
    public GameObject objTargetCar;
    public GameObject objCountdown;
    public GameObject objGoal;
    public TMP_Text textCountdown;
    public TMP_Text textTimer;
    public TMP_Text textSpeedMeter;
    private Rigidbody rb;
    private float countdown;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        objGoal.SetActive(false);

        countdown = 4;
        timer = 0;
        rb = objTargetCar.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Countdown();
        Timer();
    }
    void FixedUpdate()
    {
        textSpeedMeter.text = Mathf.Floor(rb.velocity.magnitude * 10) / 10 + " Km/h";
    }
    void Countdown()
    {
        countdown -= Time.deltaTime;
        int second = (int)countdown;

        if (second <= 0) 
        {
            textCountdown.text = "GO!!";
        }
        else
        {
            textCountdown.text = second.ToString();
        }

        if(second <= -2)
        {
            objCountdown.SetActive(false);
        }
    }
    void Timer()
    {
        timer += Time.deltaTime;
        int minute = (int)timer / 60;
        int second = (int)timer % 60;
        int msecond = (int)(timer * 100 % 100);
        string minText, secText, msecText;
        if (minute < 10)
        {
            minText = "0" + minute.ToString();
        }
        else
        {
            minText = minute.ToString();
        }

        if (second < 10)
        {
            secText = "0" + second.ToString();
        }
        else
        {
            secText = second.ToString();
        }

        if (msecond < 10)
        {
            msecText = "0" + msecond.ToString();
        }
        else
        {
            msecText = msecond.ToString();
        }

        textTimer.text = "NowTime : " + minText + "." + secText + "." + msecText;
    }
}
