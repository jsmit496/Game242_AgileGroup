using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSetter : MonoBehaviour
{
    public float chanceWeatherChange = 0.10f;
    public int maxWeatherEffects = 2;
    public int hourlyChangeRate = 1;

    public GameObject[] rainGameObjects;

    [SerializeField]
    private string weather = "Sunny"; //Rain, Sunny

    private int randomNum;
    public double currentTime = 0;
    public double timeTryChange = 60;
    private string previousWeather;
    private bool resetTimer;
    private GameTimer gameTimer;

	// Use this for initialization
	void Start ()
    {
        previousWeather = weather;
        gameTimer = GameObject.FindGameObjectWithTag("Player").GetComponent<GameTimer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        DetermineWeather();
        currentTime = (gameTimer.hour * 60) + gameTimer.minute;
	}

    public void DetermineWeather()
    {
        if (resetTimer)
        {
            timeTryChange = currentTime + (60 * hourlyChangeRate);
            resetTimer = false;
        }

        bool change = false;
        if (currentTime == timeTryChange)
        {
            change = Random.Range(0, 100) <= (100 * chanceWeatherChange);
            resetTimer = true;
        }

        if (change)
        {
            randomNum = Random.Range(0, maxWeatherEffects);

            if (randomNum == 0 && rainGameObjects != null)
            {
                previousWeather = weather;
                weather = "Sunny";
                if (weather != previousWeather)
                {
                    for (int i = 0; i < rainGameObjects.Length; i++)
                    {
                        rainGameObjects[i].SetActive(false);
                    }
                }
                change = false;
            }
            else if (randomNum == 1 && rainGameObjects != null)
            {
                previousWeather = weather;
                weather = "Rain";
                if (weather != previousWeather)
                {
                    for (int i = 0; i < rainGameObjects.Length; i++)
                    {
                        rainGameObjects[i].SetActive(true);
                    }
                }
                change = false;
            }
        }
    }
}
