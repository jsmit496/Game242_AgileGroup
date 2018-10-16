using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardingManager : MonoBehaviour {

    public GameObject boundries;

    public void Activate()
    {
        boundries.SetActive(true);
    }

    public void Deactivate()
    {
        boundries.SetActive(false);
    }
}
