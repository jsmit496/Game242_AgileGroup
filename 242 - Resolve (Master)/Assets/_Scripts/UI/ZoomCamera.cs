using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public float zoomSpeed;

    public Transform clickZoomTransform;

    private float maxZoom = 60f;
    private float minZoom = 20f;
    private bool canScrollZoom = true;
    private bool clickZoomed = false;

    private Vector3 defaultPosition;

	// Use this for initialization
	void Start ()
    {
        defaultPosition = gameObject.transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        if (canScrollZoom)
        {
            BasicScrollZoom();
        }

        MouseClickZoom();

        if (clickZoomed)
        {
            canScrollZoom = false;
        }
        else if (!clickZoomed)
        {
            canScrollZoom = true;
        }
    }

    public void BasicScrollZoom()
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

    public void MouseClickZoom()
    {
        if (Input.GetMouseButtonDown(2))
        {
            GetComponent<Camera>().fieldOfView = maxZoom;
            clickZoomed = true;
            if (clickZoomed == false)
            {
                clickZoomed = true;
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 1000.0f))
                {
                    print(hit.transform.gameObject.name + " was hit");
                    clickZoomTransform.position = hit.point;
                }
            }
            else if (clickZoomed == true)
            {
                clickZoomed = false;
                clickZoomTransform.position = defaultPosition;
            }
            
        }
    }
}
