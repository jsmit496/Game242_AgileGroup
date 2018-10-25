using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour {

    // For Text UI
    public GameObject InteractText;

    // Designates a object
    public GameObject designatedObject;

    // True/False if player is present near the object
    public bool playerPresent = false;

    // True/False if player has interacted with designated object
    public bool playerInteract = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InteractText.SetActive(true);
            InteractText.GetComponent<Text>().text = "Left Click to Interact";
            playerPresent = true;
        }
    }

    public void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Interacted");
            playerInteract = true;
        }
        else
        {
            playerInteract = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        InteractText.SetActive(false);
        InteractText.GetComponent<Text>().text = "";
        playerPresent = false;
    }

    public void Update()
    {
        if (playerInteract == true && gameObject.tag == "Interactable")
        {
            Destroy(designatedObject);
            playerInteract = true;
            InteractText.SetActive(false);
        }
    }
}
