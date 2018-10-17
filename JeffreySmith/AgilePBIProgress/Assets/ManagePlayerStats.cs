using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePlayerStats : MonoBehaviour
{
    public float decreaseSpeed = 0.5f; //use fractions (1 will be max)
    public float maxHunger = 100;
    public float maxThirst = 100;
    public float maxFatigue = 100;
    public float maxExposure = 100;
    public float maxStamina = 100;
    public float maxHealth = 100;

    public Image thirstBar;
    public Image hungerBar;
    public Slider exposureBar;
    public Image fatigueBar;
    public Image healthBarLeft;
    public Image healthBarRight;
    public Image staminaBar;

    [HideInInspector]
    public float currentHealth, currentHunger, currentThirst, exposure, currentFatigue, currentStamina;

    private TemperatureManager tempManager;

	// Use this for initialization
	void Start ()
    {
        tempManager = gameObject.GetComponent<TemperatureManager>();
        currentHunger = maxHunger;
        currentThirst = maxThirst;
        currentHealth = maxHealth;
        currentFatigue = maxFatigue;
        currentStamina = maxStamina;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ManageDecreaseOverTime();
        HandleBarDisplays();
        exposure = tempManager.currentTemperature; //This will change when adding clothing
	}

    public void ManageDecreaseOverTime()
    {
        currentHunger -= Time.deltaTime * decreaseSpeed;
        currentThirst -= Time.deltaTime * decreaseSpeed;
        currentFatigue -= Time.deltaTime * decreaseSpeed; //this may be changed later
    }

    public void HandleBarDisplays()
    {
        thirstBar.fillAmount = currentThirst / maxThirst;
        hungerBar.fillAmount = currentHunger / maxHunger;
        fatigueBar.fillAmount = currentFatigue / maxFatigue;
        exposureBar.value = exposure / maxExposure;
        healthBarLeft.fillAmount = currentHealth / maxHealth;
        healthBarRight.fillAmount = currentHealth / maxHealth;
    }

    public void HandleOverflow()
    {
        if (currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }
        if (currentThirst > maxThirst)
        {
            currentThirst = maxThirst;
        }
        if (currentFatigue > maxFatigue)
        {
            currentFatigue = maxFatigue;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
