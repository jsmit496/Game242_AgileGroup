using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceWaypoint : MonoBehaviour {


    private void OnTriggerEnter(Collider Player)
    {
        GameObject.Find("Player").GetComponent<PlayerController>().transferClimb = false;
        GameObject.Find("Player").GetComponent<PlayerController>().StopWaypoint();
        transform.parent.GetComponent<BoardingManager>().Activate();
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
