using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {

    /// <summary>
    /// Detects collisions with objects labeled "Projectile," and applies the damage to
    /// an accomponied Health component
    ///     GameObject Requires:
    ///     - Health Script Component
    ///     - Trigger Collider
    /// </summary>

    public MeleeAttack melee;
    //public Projectile projectile; //used to detect values from colliding.other
    Health health; //stores Health component
    private int meleeDamage;
    //private int projDamage; //stores the damage value from collider.other
    public int bumpDamage = 5;
    //public string projectileTag = "Projectile";
    public string bodyTag = "Player";
    

    private void Start()
    {
        health = GetComponent<Health>();
    }


    public void OnTriggerEnter(Collider other)
    //Detects objects tagged "Projectile" on trigger entrance, requires a trigger collider on the same game object
    {
        //if (other.gameObject.CompareTag(projectileTag))
        {
            //projectile = other.GetComponent<Projectile>();
           // projDamage = projectile.damage; //assigns damage value from collider.other
            //health.TakeDamage(projDamage); //call health component to apply damage 
            //projectile = null;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (other.gameObject.tag == "MeleeRange")
            {
                melee = other.GetComponent<MeleeAttack>();
                meleeDamage = melee.damage;
                health.TakeDamage(meleeDamage);
                melee = null;
            }
        }
    }

    //Applies set damage when objects tagged player collide
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(bodyTag))
        {
            health.TakeDamage(bumpDamage);
        }
    }
}
