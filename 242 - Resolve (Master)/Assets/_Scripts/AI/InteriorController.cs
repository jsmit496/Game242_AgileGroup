using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorController : MonoBehaviour
{
    public bool inside;

    public GameObject[] floors; //Floors in order from first to last
    public GameObject[] weatherOverlays;
    public GameObject[] wallsToDisable;

    GameObject[] worldLights;

	// Use this for initialization
	void Start ()
    {
        worldLights = GameObject.FindGameObjectsWithTag("WorldLight");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (inside)
        {
            foreach (GameObject obj in worldLights)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in weatherOverlays)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in wallsToDisable)
            {
                obj.SetActive(false);
            }
            for (int i = 0; i < floors.Length; i++)
            {
                DisplayObjectsOnActiveFloor(floors[i], false);
            }
        }
        else if (!inside)
        {
            foreach (GameObject obj in worldLights)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in weatherOverlays)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in wallsToDisable)
            {
                obj.SetActive(true);
            }
            for (int i = 0; i < floors.Length; i++)
            {
                DisplayObjectsOnActiveFloor(floors[i], true);
            }
        }
	}

    private void DisplayObjectsOnActiveFloor(GameObject floor, bool reset)
    {
        InteriorFloorController IFC = floor.GetComponent<InteriorFloorController>();
        if (!reset)
        {
            if (IFC.onThisFloor)
            {
                foreach (GameObject obj in IFC.objectsOnFloor)
                {
                    obj.SetActive(true);
                }
            }
            else if (!IFC.onThisFloor)
            {
                foreach (GameObject obj in IFC.objectsOnFloor)
                {
                    obj.SetActive(false);
                }
            }
        }
        else if (reset)
        {
            foreach (GameObject obj in IFC.objectsOnFloor)
            {
                obj.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = false;
        }
    }
}
