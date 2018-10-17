using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    public Transform positionToStart;

	// Use this for initialization
	void Start ()
    {
        transform.position = positionToStart.position;
	}
}
