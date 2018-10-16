using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbExit : MonoBehaviour {

    private Transform Waypoint;

    private void Start()
    {
        Waypoint = transform.parent.Find("ExitWaypoint");
    }

    private void OnTriggerEnter(Collider Player)
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().transferClimb == false)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().wayPoint = Waypoint;
        }
    }

    private void OnTriggerExit(Collider Player)
    {

    }

    private void OnTriggerStay(Collider Player)
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().allowFall == false)
        {
            if (GameObject.Find("Player").GetComponent<PlayerController>().transferClimb == false)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().wayPoint = Waypoint;
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.parent.GetComponent<BoardingManager>().Deactivate();
            GameObject.Find("Player").GetComponent<PlayerController>().transferClimb = true;
            GameObject.Find("Player").GetComponent<PlayerController>().GotoWaypoint();
        }
    }
}
