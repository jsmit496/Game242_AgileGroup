using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInspection1 : MonoBehaviour {

    // Text for UI (Shows what is being examined)
    public GameObject inspectionText;
    
    // For Text UI (Shows when to press the button)
    public GameObject InspectText;

    // True/False if player is present near the object
    public bool objectPresent = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Inspectable")
        {
            InspectText.SetActive(true);
            InspectText.GetComponent<Text>().text = "Press E to Inspect";
            objectPresent = true;

        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Inspectable")
        {
            objectPresent = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Inspected");
                inspectionText.SetActive(true);
                inspectionText.GetComponent<Text>().text = "Just a object to inspect.";
            }
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        InspectText.SetActive(false);
        inspectionText.SetActive(false);
        InspectText.GetComponent<Text>().text = "";
        objectPresent = false;
    }
}
