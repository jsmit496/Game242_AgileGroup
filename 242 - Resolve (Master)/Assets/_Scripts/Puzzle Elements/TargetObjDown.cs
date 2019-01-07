using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjDown : MonoBehaviour {

    public Animator animate;

    public TargetObj targetObject;

	public void FixedUpdate ()
    {
        if (targetObject.objectHit == true)
        {
            animate.SetBool("objEvent", true);
        }
    }
}
