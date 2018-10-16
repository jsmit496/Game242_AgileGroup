using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbEntrance : MonoBehaviour {

    private Transform Waypoint;

    private void Start()
    {
        Waypoint = transform.parent.Find("EntranceWaypoint");
    }

    private void OnTriggerEnter(Collider Player)
    {
        
    }

    private void OnTriggerExit(Collider Player)
    {

    }

    private void OnTriggerStay(Collider Player)
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().transferClimb == false)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().wayPoint = Waypoint;
        }
        if (Input.GetKey(KeyCode.E))
        {
            GameObject.Find("Player").GetComponent<PlayerController>().transferClimb = true;
            GameObject.Find("Player").GetComponent<PlayerController>().allowFall = false;
            GameObject.Find("Player").GetComponent<PlayerController>().GotoWaypoint();
        }
    }
}
