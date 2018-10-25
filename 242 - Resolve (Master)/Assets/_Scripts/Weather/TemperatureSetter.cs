using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureSetter : MonoBehaviour
{
    public int baseTemperature = 60;
    public int dayBaseTemperature = 60;
    public int nightBaseTemperature = 50;
    public int hourDayStart = 8;
    public int hourNightStart = 20;

    private GameTimer gameTimer;

    private void Start()
    {
        gameTimer = GameObject.FindGameObjectWithTag("Player").GetComponent<GameTimer>();
    }

    private void Update()
    {
        if (gameTimer.hour == hourNightStart)
        {
            baseTemperature = nightBaseTemperature;
        }
        else if (gameTimer.hour == hourDayStart)
        {
            baseTemperature = dayBaseTemperature;
        }
    }
}
