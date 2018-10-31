using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;

	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 4);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, 4);
	}
}
