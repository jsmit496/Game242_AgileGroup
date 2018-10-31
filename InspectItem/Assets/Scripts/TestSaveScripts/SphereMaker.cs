using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMaker : MonoBehaviour
{
    public GameObject sphereTemplate;
    public int maxSpheres = 3;

    int numCreated = 0;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numCreated < maxSpheres)
        {
            GameObject newSphere = GameObject.Instantiate(sphereTemplate);
            newSphere.transform.position = newSphere.transform.position + Vector3.up * numCreated;

            newSphere.GetComponent<MoveCube>().moveSpeed = Random.Range(3f, 7f);

            numCreated++;
        }
	}
}
