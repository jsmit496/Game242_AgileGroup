using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeColorSwap : MonoBehaviour {

    public GameObject timeController;
    public  float curTime;
    public Image i;

    public float dayHour;
    public Color dayColor = new Color(0, 0, 0, .8f);
    public float nightHour;
    public Color nightColor = new Color(1, 1, 1, .8f);

	// Use this for initialization
	void Start () {

        timeController = GameObject.FindGameObjectWithTag("TimeController");
        i = this.gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        curTime = timeController.GetComponent<MainTimeScript>().Get_fCurrentHour;


        if (i != null)
        {
            if (curTime >= dayHour && curTime <= nightHour)
            {
                ChangeColor(dayColor);
            }
            else if (curTime >= nightHour || curTime <= dayHour)
            {
                ChangeColor(nightColor);
            }
        }

    }

    public void ChangeColor(Color col)
    {
        i.color = col;
    }
}
