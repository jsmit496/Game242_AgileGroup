using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour {

    public bool playerPresent = false;
    public float pushForce = 1.0f;
    public Transform direction = null;
    private Rigidbody rb;

    void Start ()
    {

    }
	
	void Update ()
    {
        //if (this.direction != null && gameObject.tag == "Player")
        {
            //rb.AddForce(direction.forward * pushForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * 100);
            GetComponent<Rigidbody>().useGravity = true;
            playerPresent = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerPresent = false;
        }
    }
}
