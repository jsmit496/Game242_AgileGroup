using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlightInspection : MonoBehaviour {

    public GameObject objectInspected;

    public int redColor;
    public int greenColor;
    public int blueColor;

    public bool playerView = false;

    public bool flashingIn = true;

    public bool beginFlashing = false;

    public void Update()
    {
        if (playerView == true)
        {
            objectInspected.GetComponent<Renderer>().material.color = new Color32((byte)redColor, (byte)greenColor, (byte)blueColor, 255);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "PlayerView")
        {
            playerView = true;
            if (beginFlashing == false)
            {
                beginFlashing = true;
                StartCoroutine(FlashObject());
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        playerView = false;
        beginFlashing = false;
        StopCoroutine(FlashObject());
        objectInspected.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
    }

    IEnumerator FlashObject()
    {
        while (playerView == true)
        {
            yield return new WaitForSeconds(0.05f);
            if (flashingIn == true)
            {
                if (greenColor <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    greenColor -= 10;
                    blueColor -= 1;
                }
            }
            if (flashingIn == false)
            {
                if (greenColor >= 250)
                {
                    flashingIn = true;
                }
                else
                {
                    greenColor += 10;
                    blueColor += 1;
                }
            }
        }
    }
}
