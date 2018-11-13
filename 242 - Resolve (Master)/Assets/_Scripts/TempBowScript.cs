using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBowScript : MonoBehaviour {

    [SerializeField]
    GameObject arrowPrefab;
    [SerializeField]
    GameObject arrow;
    [SerializeField]
    int numberOfArrows = 10;
    bool arrowSlotted = false;
    private bool isReloading = false;
    float arrowDraw = 0;
	void Start ()
    {
        SpawnArrow();
	}




    void Update ()
    {
        if (isReloading == true)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            arrow.GetComponent<ArrowScript>().ApplyForce();
            numberOfArrows--;
            StartCoroutine(Reload());
            return;
        }

       
    }

    void SpawnArrow()
    {
        if(numberOfArrows > 0)
        {
            arrowSlotted = true;
            arrow = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject;
            arrow.transform.parent = transform;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(2);
        isReloading = false;
        SpawnArrow();
    }

}
