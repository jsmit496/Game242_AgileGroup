using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraHController : MonoBehaviour
{
    public Transform cameraMenuTransform;
    public Transform cameraMapTransform;

	// Use this for initialization
	void Start ()
    {
        gameObject.transform.position = cameraMenuTransform.position;
        //Set rotation to look at map 
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleCameraPositionChange();
	}

    private void HandleCameraPositionChange()
    {
        //When loading move camera to map position and rotate to look at map
    }
}
