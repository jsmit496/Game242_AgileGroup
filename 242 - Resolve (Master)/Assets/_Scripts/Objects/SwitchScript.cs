using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchScript : MonoBehaviour {

    // For Text UI
    public GameObject SwitchText;

    // Given Object
    public GameObject designatedObject;

    // True/False Switch being pressed
    public bool switchPressed = false;

    // True/False if player is present near the object
    public bool playerPresent = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SwitchText.SetActive(true);
            SwitchText.GetComponent<Text>().text = "Left Click to activate Switch";
            playerPresent = true;
        }
    }

    public void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            switchPressed = true;
            Debug.Log("Switch Pressed");
        }
    }

    void OnTriggerExit(Collider other)
    {
        SwitchText.SetActive(false);
        SwitchText.GetComponent<Text>().text = "";
        playerPresent = false;
    }

    public void Update()
    {
        if (switchPressed == true)
        {
            designatedObject.transform.Translate(Vector3.down * Time.deltaTime);
            switchPressed = true;
        }
    }
}
