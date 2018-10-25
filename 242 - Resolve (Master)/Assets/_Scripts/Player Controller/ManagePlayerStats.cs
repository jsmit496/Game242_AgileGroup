using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePlayerStats : MonoBehaviour
{
    public float decreaseSpeed = 0.5f; //use fractions (1 will be max)
    public float refillSpeed = 1f;
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
        if (currentStamina < maxStamina)
        {
            currentStamina += ((currentStamina / maxStamina) + (refillSpeed / 2)) * Time.deltaTime * refillSpeed;
        }
        HandleOverflow();
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
        staminaBar.fillAmount = currentStamina / maxStamina;
    }

    public void HandleOverflow()
    {
        if (currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }
        else if (currentHunger < 0)
        {
            currentHunger = 0;
        }
        if (currentThirst > maxThirst)
        {
            currentThirst = maxThirst;
        }
        else if (currentThirst < 0)
        {
            currentThirst = 0;
        }
        if (currentFatigue > maxFatigue)
        {
            currentFatigue = maxFatigue;
        }
        else if (currentFatigue < 0)
        {
            currentFatigue = 0;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
        else if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }
}
