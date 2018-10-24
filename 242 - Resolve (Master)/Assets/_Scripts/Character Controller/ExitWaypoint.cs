using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWaypoint : MonoBehaviour {

    private void OnTriggerEnter(Collider Player)
    {
        GameObject.Find("Player").GetComponent<PlayerController>().transferClimb = false;
        GameObject.Find("Player").GetComponent<PlayerController>().allowFall = true;
        GameObject.Find("Player").GetComponent<PlayerController>().ResetMovement();
    }

    private void OnTriggerExit(Collider Player)
    {

    }

    private void OnTriggerStay(Collider Player)
    {
        if (Input.GetKey(KeyCode.E))
        {

        }
    }
}
