using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempHealth : MonoBehaviour
{


    public int health;

    private void Start()
    {

    }

    private void Update()
    {
        Debug.Log(health);
        if (health <= 0)
            Die();
    }

    public void TakeDamage(int Amount)
    {
        health = health - Amount;
    }

    void Die()
    {
        Destroy(gameObject);
    }


}
