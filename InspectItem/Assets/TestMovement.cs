using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{

    public float speed = 4.0f;
    public float motionScale = 90f;
    public float maxAngle = 90f;

    public GameObject playerCamera;

    private CursorLockMode cursorMode;

    void SetCursorState()
    {
        Cursor.lockState = cursorMode;
        Cursor.visible = (CursorLockMode.Locked != cursorMode);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BasicFirstPersonControls();
    }

    private void BasicFirstPersonControls()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //gameObject.GetComponent<Rigidbody>().velocity = transform.forward * Time.deltaTime * speed;
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody>().velocity = -transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody>().velocity = -transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.right * Time.deltaTime * speed;
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (mouseX > 0 || mouseY > 0)
        {
            transform.Rotate(Vector3.up, mouseX * motionScale * Time.deltaTime, Space.World);

            CameraUpDownMovement();
        }
        if (mouseX < 0 || mouseY < 0)
        {
            transform.Rotate(Vector3.down, -mouseX * motionScale * Time.deltaTime, Space.World);

            CameraUpDownMovement();
        }

        //This will also deal with opening the menu and what not
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (cursorMode != CursorLockMode.Locked)
            {
                cursorMode = CursorLockMode.Locked;
            }
            else if (cursorMode == CursorLockMode.Locked)
            {
                cursorMode = CursorLockMode.None;
            }
            SetCursorState();
        }
    }

    public void CameraUpDownMovement()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        if (mouseY > 0)
        {
            playerCamera.transform.Rotate(-transform.right, mouseY * motionScale * Time.deltaTime, Space.World);

            if (Vector3.Angle(transform.forward, playerCamera.transform.forward) > maxAngle)
            {
                playerCamera.transform.forward = transform.forward;
                playerCamera.transform.Rotate(-transform.right, maxAngle, Space.World);
            }
        }
        if (mouseY < 0)
        {
            playerCamera.transform.Rotate(transform.right, -mouseY * motionScale * Time.deltaTime, Space.World);

            if (Vector3.Angle(transform.forward, playerCamera.transform.forward) > maxAngle)
            {
                playerCamera.transform.forward = transform.forward;
                playerCamera.transform.Rotate(transform.right, maxAngle, Space.World);
            }
        }
    }
}
