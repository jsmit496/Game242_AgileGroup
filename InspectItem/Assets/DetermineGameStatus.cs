using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineGameStatus : MonoBehaviour
{
    public bool gameOver = false;

    //[HideInInspector]
    public int numItemsFound;

    //[HideInInspector]
    public int numItemsToFind;

    private bool callAnalytics = false;

    private List<GameObject> itemsToFind = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        itemsToFind.AddRange(GameObject.FindGameObjectsWithTag("Pickup"));
        foreach (GameObject gbj in itemsToFind)
        {
            numItemsToFind++;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (numItemsFound == numItemsToFind)
        {
            gameOver = true;
        }
        if (gameOver)
        {
            if (!callAnalytics)
            {
                gameObject.GetComponent<Analytics>().FoundAllObjects(gameOver);
                callAnalytics = true;
            }
            Application.Quit();
        }
	}

    private void OnApplicationQuit()
    {
        if (!gameOver)
        {
            if (!callAnalytics)
            {
                gameObject.GetComponent<Analytics>().FoundAllObjects(gameOver);
                callAnalytics = true;
            }
        }
    }
}
