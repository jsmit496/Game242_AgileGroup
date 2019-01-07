using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Devdog.InventoryPro;

public class invAddItem : MonoBehaviour {

    // For Text UI
    public GameObject InteractText;

    // True/False if player is present near the object
    public bool playerPresent = false;

    // True/False if player has interacted with designated object
    public bool playerInteract = false;

    //Communicates which item the object represents to Inventory Pro
    public InventoryItemBase item;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InteractText.SetActive(true);
            InteractText.GetComponent<Text>().text = "Left Click to Interact";
            playerPresent = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InteractText.SetActive(true);
            InteractText.GetComponent<Text>().text = "Left Click to Interact";
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("Collected");
                playerInteract = true;
                InventoryManager.AddItem(item);
                DestroyObject();
            }
            else
            {
                playerInteract = false;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        InteractText.SetActive(false);
        InteractText.GetComponent<Text>().text = "";
        playerPresent = false;
    }

    public void DestroyObject()
    {

        Destroy(this);
        InteractText.SetActive(false);
    }
}
