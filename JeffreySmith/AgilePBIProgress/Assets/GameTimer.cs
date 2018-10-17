using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public int timeScale = 45; //this will change how fast time passes
    public Text clockText;

    public double second, minute, hour;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CalculateTime();
	}

    public void CalculateTime()
    {
        second += Time.deltaTime * timeScale;

        if (second >= 60)
        {
            minute++;
            second = 0;
        }
        else if (minute >= 60)
        {
            hour++;
            minute = 0;
        }
        else if (hour >= 24)
        {
            hour = 0;
        }

        //How to display Time
        if (hour >= 10 && minute >= 10)
        {
            if (minute >= 10)
            {
                clockText.text = string.Format("{0}:{1}", hour, minute);
            }
            else if (minute < 10 && minute > 0)
            {
                clockText.text = string.Format("{0}:0{1}", hour, minute);
            }
            else if (minute == 0)
            {
                clockText.text = string.Format("{0}:00", hour);
            }
        }
        else if (hour <= 10 && hour > 0)
        {
            if (minute >= 10)
            {
                clockText.text = string.Format("0{0}:{1}", hour, minute);
            }
            else if (minute < 10 && minute > 0)
            {
                clockText.text = string.Format("0{0}:0{1}", hour, minute);
            }
            else if (minute == 0)
            {
                clockText.text = string.Format("0{0}:00", hour);
            }
        }
        else if (hour == 0)
        {
            if (minute >= 10)
            {
                clockText.text = string.Format("00:{1}", hour, minute);
            }
            else if (minute < 10 && minute > 0)
            {
                clockText.text = string.Format("00:0{1}", hour, minute);
            }
            else if (minute == 0)
            {
                clockText.text = string.Format("00:00");
            }
        }
    }
}
