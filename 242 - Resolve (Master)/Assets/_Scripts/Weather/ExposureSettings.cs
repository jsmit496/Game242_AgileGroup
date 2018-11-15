using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExposureSettings : MonoBehaviour
{
    public float exposure = 0;

    public Image hungerBackgroundBar;
    public Image hungerMoveBar;

    private TemperatureManager tempManage;

	// Use this for initialization
	void Start ()
    {
        tempManage = GetComponent<TemperatureManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleExposure();
	}

    public void HandleExposure()
    {
        exposure = tempManage.currentTemperature;
        if (exposure > 100)
        {
            exposure = 100;
        }
        else if (exposure < 0)
        {
            //This may change if snow does soemthing
            exposure = 0;
        }
        //calculate the new size of exposure bar by what the percent of the exposure out of 100 compared to the size of the width multiplied by that percent

    }
}
