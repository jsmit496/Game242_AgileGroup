using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorFloorController : MonoBehaviour
{
    public GameObject[] objectsOnFloor; //This will include lights, the floor, and anything else on it
    public bool onThisFloor = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onThisFloor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onThisFloor = false;
        }
    }
}
