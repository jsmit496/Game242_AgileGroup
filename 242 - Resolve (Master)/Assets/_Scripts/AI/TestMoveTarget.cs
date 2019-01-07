using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveTarget : MonoBehaviour
{
    public LayerMask floor;
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, floor))
            {
                transform.position = hit.point;
            }
        }
	}
}
