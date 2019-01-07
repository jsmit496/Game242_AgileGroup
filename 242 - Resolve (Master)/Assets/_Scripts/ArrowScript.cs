using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    [SerializeField]
    int speed = 5;
    int destroyArrowTime = 3;
    bool arrowLoosed = false;
    bool arrowEmbedded = false;

	void Enable ()
    {

	}
	
	void Update ()
    {
        if (arrowLoosed == true)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if(arrowEmbedded == true)
        {
            Destroy(gameObject, 5f);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        transform.parent = other.transform;
        Embed();
    }

    public void ApplyForce()
    {
        transform.parent = null;
        arrowLoosed = true;

    }

    void Embed()
    {
        arrowLoosed = false;
        GetComponent<Collider>().enabled = false;
        arrowEmbedded = true;
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
