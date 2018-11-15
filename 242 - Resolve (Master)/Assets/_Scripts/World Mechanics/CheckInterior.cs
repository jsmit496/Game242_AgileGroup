using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInterior : MonoBehaviour
{
    public bool inside = false;
    public GameObject[] weatherOverlays;

    private bool setForInside;

    private void Update()
    {
        if (inside == true && !setForInside)
        {
            for (int i = 0; i < weatherOverlays.Length; i++)
            {
                weatherOverlays[i].SetActive(false);
            }
            setForInside = true;
        }
        else if (inside == false && !setForInside)
        {
            for (int i = 0; i < weatherOverlays.Length; i++)
            {
                weatherOverlays[i].SetActive(true);
            }
            setForInside = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = true;
            setForInside = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = false;
            setForInside = false;
        }
    }
}
