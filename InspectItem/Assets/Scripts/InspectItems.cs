using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectItems : MonoBehaviour
{
    //BUG: create script on interactable objects that handles movement so that it will finish the job even if I am not hovered on it.
    //in its current state if you leave the cube so its not interactable then it will not reset properly. To fix this make sure movement
    //runs on its own in another script on the object and just call it here.

    //Add the IMI enable/disable

    public float rayDistance = 5f;
    public float itemMovementSpeed = 5f;
    public float targetScale = 0.1f;
    public float shrinkSpeed = 0.1f;
    public float resetRotationSpeed = 5f;
    public float motionScale = 90f;
    public float objectDistanceFromCamera = 4.0f;

    private bool canPickup = false;
    private bool moveObject = false;
    private bool resetRotation = false;

    private PlayerMovement playerMovement;
    private GameObject itemToPickup;
    private Camera playerCamera;

    private Quaternion itemToPickupRotation;
    private Vector3 itemToPickupPosition;
    private Vector3 itemToPickupScale;

    private ResetObject resetObject;
    private InspectMenuInteraction IMI;

	// Use this for initialization
	void Start ()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerCamera = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();
        IMI = GameObject.FindGameObjectWithTag("Player").GetComponent<InspectMenuInteraction>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckIfCanPickup();
        HandlePickup();
        if (moveObject)
        {
            RotateItem();
        }
	}

    public void CheckIfCanPickup()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.transform.gameObject.tag == "Pickup")
            {
                //Display the "Press E to pick up"
                canPickup = true;
                itemToPickup = hit.transform.gameObject;
                resetObject = itemToPickup.GetComponent<ResetObject>();
            }
            else
            {
                canPickup = false;
                itemToPickup = null;
                moveObject = false;
            }
        }
    }

    public void HandlePickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canPickup && !moveObject)
            {
                moveObject = true;
                playerMovement.enabled = false;
                resetObject.reset = false;
            }
            else if (moveObject)
            {
                moveObject = false;
                playerMovement.enabled = true;
                resetObject.reset = true;
                resetObject.objectFound = true;
                canPickup = false;
            }
        }

        if (moveObject == true)
        {
            Vector3 itemScreenPosition = playerCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, playerCamera.nearClipPlane * objectDistanceFromCamera));

            itemToPickup.transform.localScale = Vector3.Lerp(itemToPickup.transform.localScale, new Vector3(targetScale, targetScale, targetScale), shrinkSpeed * Time.deltaTime);
            itemToPickup.transform.position = Vector3.Lerp(itemToPickup.transform.position, itemScreenPosition, itemMovementSpeed * Time.deltaTime);
        }
    }

    public void RotateItem()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (mouseX > 0 || mouseY > 0 && !resetRotation)
        {
            itemToPickup.transform.Rotate(Vector3.up, -mouseX * motionScale * Time.deltaTime, Space.World);

            UpDownMovement();
        }
        if (mouseX < 0 || mouseY < 0 && !resetRotation)
        {
            itemToPickup.transform.Rotate(Vector3.down, mouseX * motionScale * Time.deltaTime, Space.World);

            UpDownMovement();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            resetRotation = true;
        }

        if (resetRotation == true)
        {
            itemToPickup.transform.rotation = Quaternion.Lerp(itemToPickup.transform.rotation, resetObject.originalRotation, resetRotationSpeed * Time.deltaTime);
            if (itemToPickup.transform.rotation == resetObject.originalRotation)
            {
                resetRotation = false;
            }
        }
    }

    public void UpDownMovement()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        if (mouseY > 0)
        {
            itemToPickup.transform.Rotate(Vector3.left, -mouseY * motionScale * Time.deltaTime, Space.World);
        }
        if (mouseY < 0)
        {
            itemToPickup.transform.Rotate(Vector3.right, mouseY * motionScale * Time.deltaTime, Space.World);
        }
    }

    public void OnDrawGizmos()
    {
        if (canPickup)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.black;
        }
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayDistance);
    }
}
