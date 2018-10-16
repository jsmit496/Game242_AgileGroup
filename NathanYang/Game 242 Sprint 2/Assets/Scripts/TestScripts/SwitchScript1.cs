using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchScript1 : MonoBehaviour {

    // For Text UI
    public GameObject SwitchText;

    // Given Object
    public GameObject designatedObject;

    // True/False Switch being pressed
    public bool switchPressed = false;

    // True/False if player is present near the object
    public bool switchPresent = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Switch")
        {
            SwitchText.SetActive(true);
            SwitchText.GetComponent<Text>().text = "Left Click to activate Switch";
            switchPresent = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Switch")
        {
            switchPresent = true;
            if (Input.GetKeyDown(KeyCode.Mouse0) && switchPresent == true)
            {
                switchPressed = true;
                Debug.Log("Switch Pressed");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        SwitchText.SetActive(false);
        SwitchText.GetComponent<Text>().text = "";
        switchPresent = false;
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
