using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObj : MonoBehaviour {

    public GameObject tObject;

    public bool objectHit = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            objectHit = true;
        }
    }

}
