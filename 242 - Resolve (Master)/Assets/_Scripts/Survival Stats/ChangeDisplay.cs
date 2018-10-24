using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDisplay : MonoBehaviour
{
    public GameObject[] ChangeDisplayObjects;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
            else if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }
        }
	}
}
