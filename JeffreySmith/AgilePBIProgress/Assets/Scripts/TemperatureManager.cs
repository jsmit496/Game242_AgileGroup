using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureManager : MonoBehaviour
{
    public int currentTemperature;
    public Transform temperatureManager;

    public GameObject[] temperatureGauges;

    private int baseTemperature;
    private Transform oldTemperatureManager;

	// Use this for initialization
	void Start ()
    {
        SetBaseTemperature();
	}
	
	// Update is called once per frame
	void Update ()
    {
        SetBaseTemperature();
        SetTemperature();
        CheckClosestGauge();
	}

    public void SetTemperature()
    {
        if (transform.position.y > temperatureManager.position.y)
        {
            currentTemperature = (int)(baseTemperature - (transform.position.y - temperatureManager.position.y));
        }
        else
        {
            currentTemperature = baseTemperature;
        }
    }

    public void SetBaseTemperature()
    {
        baseTemperature = temperatureManager.GetComponent<TemperatureSetter>().baseTemperature;
    }

    public void CheckClosestGauge()
    {
        float currentClosestDistance = 9999999999;
        GameObject currentClosest = temperatureManager.gameObject;

        foreach (GameObject gbj in temperatureGauges)
        {
            float distance = Vector3.Distance(transform.position, gbj.transform.position);
            if (distance < currentClosestDistance)
            {
                currentClosestDistance = distance;
                currentClosest = gbj;
            }
        }
        if (temperatureManager != currentClosest.transform)
        {
            temperatureManager = currentClosest.transform;
            SetBaseTemperature();
        }
    }
}
