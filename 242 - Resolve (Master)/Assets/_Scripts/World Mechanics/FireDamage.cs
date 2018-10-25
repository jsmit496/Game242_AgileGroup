using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour {

    public Health health;

    public float fireDuration;

    public int wait;

    public bool onFire = false;

    public int fireDamage;

    public void OnTriggerEnter(Collider other)
    {
        
        if (onFire == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                onFire = true;
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (onFire == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                onFire = true;
            }
        }
    }

    public void Update()
    {
        if (onFire == true)
        {
            this.fireDuration -= Time.deltaTime;
            health.TakeDamage(fireDamage);
        }
    }
}
