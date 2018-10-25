using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    float movementSpeed;        //Speed for movement
    public float baseMovementSpeed;
    public float climbingSpeed;
    public bool movement = true;
    public bool aiControl = false;

    private Rigidbody rbody;    //Rigid body for gravity

    private Camera mainCamera;  //Camera for face cursor

    public bool climbing = false;
    public bool transferClimb = false;
    public bool allowFall = true;

    public Transform wayPoint;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (movement == true)
        {
            if (climbing == false)
            {
                #region Face Cursor
                Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
                Plane groundTerrain = new Plane(Vector3.up, Vector3.zero);
                float rayLength;

                if (groundTerrain.Raycast(cameraRay, out rayLength))
                {
                    Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                    Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

                    transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
                }
                #endregion

                #region Movement
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    transform.position += Vector3.left * movementSpeed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    transform.position += Vector3.right * movementSpeed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                {
                    transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                {
                    transform.position += Vector3.back * movementSpeed * Time.deltaTime;
                }
                #endregion
            }
            else if (climbing == true)
            {
                #region Climbing
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    transform.position += Vector3.left * climbingSpeed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    transform.position += Vector3.right * climbingSpeed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                {
                    transform.position += Vector3.up * climbingSpeed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                {
                    transform.position += Vector3.down * climbingSpeed * Time.deltaTime;
                }

                #endregion
            }
        }

        if (aiControl == true)
        {
            float step = climbingSpeed * Time.deltaTime;                                            // The step size is equal to climbing speed times frame time.
            transform.position = Vector3.MoveTowards(transform.position, wayPoint.position, step);  //Move position closer to waypoint
        }
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = baseMovementSpeed * 2;
        }
        else
        {
            movementSpeed = baseMovementSpeed;
        }
    }

    #region AI Movement Control
    public void GotoWaypoint()
    {
        rbody.useGravity = false;
        movement = false;
        aiControl = true;
    }

    public void StopWaypoint()
    {
        aiControl = false;
        climbing = true;
        movement = true;
    }

    public void ResetMovement()
    {
        aiControl = false;
        rbody.useGravity = true;
        climbing = false;
        movement = true;
    }

    #endregion

}
