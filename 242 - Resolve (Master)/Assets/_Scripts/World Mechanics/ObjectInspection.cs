using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInspection : MonoBehaviour {

    // Text for UI (Shows what is being examined)
    public GameObject inspectionText;
    
    // For Text UI (Shows when to press the button)
    public GameObject InspectText;

    // True/False if player is present near the object
    public bool playerView = false;


    public void OnTriggerEnter(Collider other)
    {
        playerView = true;
        if (other.gameObject.tag == "PlayerView")
        {
            InspectText.SetActive(true);
            InspectText.GetComponent<Text>().text = "Press E to Inspect";
            enabled = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        playerView = true;
        if (other.gameObject.tag == "PlayerView")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Inspected");
                inspectionText.SetActive(true);
                inspectionText.GetComponent<Text>().text = "Just a object to inspect.";
                enabled = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        InspectText.SetActive(false);
        inspectionText.SetActive(false);
        InspectText.GetComponent<Text>().text = "";
        playerView = false;
        enabled = false;
    }
}
