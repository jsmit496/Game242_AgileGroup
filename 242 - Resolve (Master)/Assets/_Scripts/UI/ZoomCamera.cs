using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public float zoomSpeed;

    private float maxZoom = 60f;
    private float minZoom = 20f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetAxis("Mouse ScrollWheel") > 0 && GetComponent<Camera>().fieldOfView >= minZoom)
        {
            GetComponent<Camera>().fieldOfView -= zoomSpeed * 100 * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && GetComponent<Camera>().fieldOfView <= maxZoom)
        {
            GetComponent<Camera>().fieldOfView += zoomSpeed * 100 * Time.deltaTime;
        }

        if (GetComponent<Camera>().fieldOfView > maxZoom)
        {
            GetComponent<Camera>().fieldOfView = maxZoom;
        }
        if (GetComponent<Camera>().fieldOfView <= minZoom)
        {
            GetComponent<Camera>().fieldOfView = minZoom;
        }

    }
}
