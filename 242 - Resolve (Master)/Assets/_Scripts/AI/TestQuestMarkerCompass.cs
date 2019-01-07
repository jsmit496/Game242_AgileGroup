using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestQuestMarkerCompass : MonoBehaviour
{
    public Transform target;
    public GameObject compassArrow;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        DetermineQuestDirection();
    }

    public void DetermineQuestDirection()
    {
        Quaternion arrowRotation;
        Vector3 direction = transform.position - target.position;

        arrowRotation = Quaternion.LookRotation(direction);

        arrowRotation.z = -arrowRotation.y;
        arrowRotation.x = 0;
        arrowRotation.y = 0;

        compassArrow.transform.localRotation = arrowRotation * Quaternion.Euler(0, 0, 225);
    }
}
