using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class UI_GameMode : MonoBehaviour
{
    public GameObject objCar;
    public TMP_Text textTimer;
    public TMP_Text textSpeedMeter;
    private Rigidbody rb;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        rb = objCar.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
		int minute = (int)time / 60;
		int second = (int)time % 60;
		int msecond = (int)(time * 100 % 100);
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

    void FixedUpdate()
    {
        textSpeedMeter.text = Mathf.Floor(rb.velocity.magnitude * 10) / 10 + " Km/h";
    }
}
