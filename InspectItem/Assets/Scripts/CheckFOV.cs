using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFOV : MonoBehaviour
{
    public float maxRadius; // This will determine how close you need to be

    public float maxAngle = 30f; //FOV for looking at an object

    private List<GameObject> objectsToFind = new List<GameObject>();

    //private Camera playerCamera;

	// Use this for initialization
	void Start ()
    {
        objectsToFind.AddRange(GameObject.FindGameObjectsWithTag("Pickup"));
        //playerCamera = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();
        //maxAngle = playerCamera.fieldOfView / 2f; //use this if you want to default set it to the camera FOV
	}
	
	// Update is called once per frame
	void Update ()
    {
        inFOV(objectsToFind, maxAngle, maxRadius);
	}

    public void inFOV(List<GameObject> objects, float maxAngle, float maxRadiu)
    {
        List<Collider> overlaps = new List<Collider>();
        overlaps.AddRange(Physics.OverlapSphere(transform.position, maxRadius));

        foreach (GameObject obj in objects)
        {
            if (overlaps.Contains(obj.GetComponent<Collider>()))
            {
                Vector3 directionBetween = (obj.transform.position - gameObject.transform.position).normalized;

                float angle = Vector3.Angle(gameObject.transform.forward, directionBetween);

                if (angle <= maxAngle)
                {
                    Ray ray = new Ray(transform.position, obj.transform.position - transform.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, maxRadius))
                    {
                        if (hit.transform.gameObject == obj)
                        {
                            print(string.Format("{0} is in the FOV", obj.name));
                            obj.GetComponent<EditObjectGlow>().MakeGlow();
                        }
                        else
                        {
                            obj.GetComponent<EditObjectGlow>().StopGlow();
                        }
                    }
                }
                else
                {
                    obj.GetComponent<EditObjectGlow>().StopGlow();
                }
            }
            else
            {
                obj.GetComponent<EditObjectGlow>().StopGlow();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);
    }
}
