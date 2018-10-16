using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    /// <summary>
    /// Pairs with the Hitbox script
    /// Holds all health data for entities and deals with death sequences
    /// </summary>

    public bool canTakeDamage = true;
    public bool mortalityCheck = true; //False is dead
    public int maxHealth; //user defined health
    public int curHealth; //current health

    public Text healthBar = null;

    ParticleSystem deathParticle; 
    SpriteRenderer sprite;
    public int flashTime;
    public GameObject drop; //drops an object on death

    public void Start()
    {
        curHealth = maxHealth;
        deathParticle = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer > ();
    }

    public void Update()
    {
        if (healthBar !=null)
        {
            healthBar.text = curHealth.ToString();
        }
    }

    //
    public void TakeDamage(int amount)
    {
        if(canTakeDamage)
        {
            curHealth -= amount; //Damage dealing for(var n = 0; n < 5; n++)
            if (curHealth <= 0) //Checks for deads
            {
                {
                    curHealth = 0;
                    mortalityCheck = false;
                }
            }

            if (!mortalityCheck)
            {
                Die();
            }
            else
            {
                StartCoroutine(FlashSprite());
            }
        }
    }

    public void Die()
    {
        sprite.enabled = false;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        Destroy(this.gameObject, deathParticle.main.duration);
        if (!deathParticle.isPlaying)
        {
            deathParticle.Play();
            if (drop != null)
            {
                Instantiate(drop, transform.position, transform.rotation);
            }
        }
    }

    IEnumerator FlashSprite()
    {
        for (var n = 0; n < flashTime; n++)
        {
            canTakeDamage = false;
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
        }
        sprite.enabled = true;
        canTakeDamage = true;
    }
}
