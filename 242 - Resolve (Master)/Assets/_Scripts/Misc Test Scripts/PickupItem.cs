using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private List<GameObject> objectsToPickup = new List<GameObject>();

    private ManagePlayerStats playerStats;

	// Use this for initialization
	void Start ()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<ManagePlayerStats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject item in objectsToPickup)
            {
                GameObject objDestroy = item;
                if (item.GetComponent<PickupType>().restoreHunger)
                {
                    playerStats.currentHunger += item.GetComponent<PickupType>().restoreAmount;
                }
                if (item.GetComponent<PickupType>().restoreThirst)
                {
                    playerStats.currentThirst += item.GetComponent<PickupType>().restoreAmount;
                }
                objectsToPickup.Remove(item);
                Destroy(objDestroy.gameObject);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            other.GetComponent<SetCanvasToObject>().objectCanvas.SetActive(true);
            if (!objectsToPickup.Contains(other.gameObject))
            {
                objectsToPickup.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            other.GetComponent<SetCanvasToObject>().objectCanvas.SetActive(false);
            if (objectsToPickup.Contains(other.gameObject))
            {
                objectsToPickup.Remove(other.gameObject);
            }
        }
    }
}
