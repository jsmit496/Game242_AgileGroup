using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour {

    public GameObject player;

    public GameObject targetObject;

    public float objectMass = 0;

    public bool isGrabbed = false;

    public bool playerPresent = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerPresent = true;
            objectGrab();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerPresent = true;
            objectGrab();
            checkLetGo();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        playerPresent = false;
    }

    public void objectGrab()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isGrabbed = !isGrabbed;
            targetObject.transform.parent = player.transform;
            Debug.Log("Object grabbed");
        }
    }

    public void checkLetGo()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ObjectLetGo();
        }
    }

    public void ObjectLetGo()
    {
        if (isGrabbed == false)
        {
            //isGrabbed = false;
            targetObject.transform.parent = null;
            Debug.Log("Object let go");
        }
    }
}
