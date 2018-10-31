using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text clockText;

    [HideInInspector]
    public int hour = 0;
    [HideInInspector]
    public int minute = 0;

    private MainTimeScript mainTimeScript;

    // Use this for initialization
    void Start ()
    {
        mainTimeScript = GameObject.FindGameObjectWithTag("TimeController").GetComponent<MainTimeScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CalculateTime();
        hour = (int)mainTimeScript._fCurrentHour;
        minute = (int)mainTimeScript._fCurrentMinute;
    }

    public void CalculateTime()
    {
        //How to display Time
        if (hour >= 10)
        {
            if (minute >= 10)
            {
                clockText.text = string.Format("{0}:{1}", hour, minute);
            }
            else if (minute < 10 && minute > 0)
            {
                clockText.text = string.Format("{0}:0{1}", hour, minute);
            }
            else
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
            else
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
            else
            {
                clockText.text = string.Format("00:00");
            }
        }
    }
}
