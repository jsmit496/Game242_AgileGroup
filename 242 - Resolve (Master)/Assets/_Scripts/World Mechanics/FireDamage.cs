using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour {

    public Health health;

    public float fireDuration;

    public int wait;

    public bool onFire = false;

    public bool playerPresent = false;

    public bool objectNear = false;

    public int fireDamage;

    public float timer;


    public void OnTriggerEnter(Collider other)
    {
        if (onFire == true)
        {
            FireDamage fs;
            fs = other.GetComponent<FireDamage>();
            fs.onFire = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerPresent = true;
            if (onFire == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    StartCoroutine(FireDamageOverTime());
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        playerPresent = false;
    }

    public void Update()
    {
        //Fire();
        StartCoroutine(FireDamageOverTime());
    }

    public void Fire()
    {
        if (onFire == true)
        {
            this.fireDuration -= Time.deltaTime;
            health.TakeDamage(fireDamage);
        }
    }

    IEnumerator FireDamageOverTime()
    {
        while (onFire == true)
        {
            yield return new WaitForSeconds(1.5f);
            health.TakeDamage(fireDamage);
        }
    }
}
