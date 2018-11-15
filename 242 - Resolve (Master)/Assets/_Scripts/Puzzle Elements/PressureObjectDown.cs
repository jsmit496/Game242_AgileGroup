using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureObjectDown : MonoBehaviour {

    public PressurePlate pressurePlate;

    public Animator animate;

    public void FixedUpdate()
    {
        if (pressurePlate.objectOnPlate == true)
        {
            animate.SetBool("objEvent", true);
        }
        else
        {
            animate.SetBool("objEvent", false);
        }
    }
}
