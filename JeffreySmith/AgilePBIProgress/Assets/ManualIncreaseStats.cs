using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualIncreaseStats : MonoBehaviour
{


    private ManagePlayerStats playerStats;

	// Use this for initialization
	void Start ()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<ManagePlayerStats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey(KeyCode.RightArrow))
        {
            playerStats.currentHealth += 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerStats.currentHealth -= 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerStats.currentFatigue += 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerStats.currentStamina -= 1;
        }
	}
}
