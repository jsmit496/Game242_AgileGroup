using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction1 : MonoBehaviour {

    // For Text UI
    public GameObject InteractText;

    // Designates a object
    public GameObject designatedObject;

    // True/False if player is present near the object
    public bool objectPresent = false;

    // True/False if player has interacted with designated object
    public bool objectInteract = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            InteractText.SetActive(true);
            InteractText.GetComponent<Text>().text = "Left Click to Interact";
            objectPresent = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        objectPresent = true;
        if (other.gameObject.tag == "Interactable")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Interacted");
                objectInteract = true;

                if (objectInteract == true && gameObject.tag == "Interactable")
                {
                    Destroy(this.gameObject);
                    objectInteract = true;
                    InteractText.SetActive(false);
                }
            }
            else
            {
                objectInteract = false;
            }
        }
    }

    public void OnTriggerExit(Collider player)
    {
        InteractText.SetActive(false);
        InteractText.GetComponent<Text>().text = "";
        objectPresent = false;
    }

    public void Update()
    {

    }
}
