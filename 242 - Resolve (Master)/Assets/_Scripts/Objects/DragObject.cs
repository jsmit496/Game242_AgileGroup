using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

    public GameObject player;
    bool dragged = false;

	// Use this for initialization
	void Start () {
		
	}

    public void activated()
    {
        if (!dragged)
        {
            dragged = true;
            Debug.Log("dragged");
            this.GetComponent<Rigidbody>().mass = 1;
            this.gameObject.AddComponent<FixedJoint>();
            this.GetComponent<FixedJoint>().connectedBody = FindObjectOfType<PlayerController>().GetComponent<Rigidbody>();
        }
        else
        {
            dragged = false;
            Debug.Log("undragged");
            this.GetComponent<Rigidbody>().mass = 1000;
            Destroy(this.gameObject.GetComponent<FixedJoint>());
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
