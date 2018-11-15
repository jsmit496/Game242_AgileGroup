using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlightInteraction : MonoBehaviour {

    public GameObject objectInspected;

    public int redColor;
    public int greenColor;
    public int blueColor;

    public bool playerPresent = false;

    public bool flashingIn = true;

    public bool beginFlashing = false;

    public void Update()
    {
        if (playerPresent == true)
        {
            objectInspected.GetComponent<Renderer>().material.color = new Color32((byte)redColor, (byte)greenColor, (byte)blueColor, 255);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
            playerPresent = true;
            if (beginFlashing == false)
            {
                beginFlashing = true;
                StartCoroutine(FlashObject());
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        playerPresent = false;
        beginFlashing = false;
        StopCoroutine(FlashObject());
        objectInspected.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
    }

    IEnumerator FlashObject()
    {
        while (playerPresent == true)
        {
            yield return new WaitForSeconds(0.05f);
            if (flashingIn == true)
            {
                if (redColor <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    redColor -= 25;
                    greenColor -= 25;
                }
            }
            if (flashingIn == false)
            {
                if (redColor >= 250)
                {
                    flashingIn = true;
                }
                else
                {
                    redColor += 25;
                    greenColor += 25;
                }
            }
        }
    }
}
