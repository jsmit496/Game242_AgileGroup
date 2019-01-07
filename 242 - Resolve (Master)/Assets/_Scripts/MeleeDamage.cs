using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour {

    [SerializeField]
    int damage;
    bool attackActive = false;
    bool wait = false;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (wait == true) return;
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
            attackActive = true;
        }
            
    }
    public void OnTriggerEnter(Collider other)
    {
        if(attackActive == true)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<TempHealth>().TakeDamage(damage);
            }
        }
    }

    public void EndAttack()
    {
        attackActive = false;
        StartCoroutine(WaitTime());
        return;
    }

    IEnumerator WaitTime()
    {
        wait = true;
        yield return new WaitForSeconds(0.5f);
        wait = false;
    }
}
