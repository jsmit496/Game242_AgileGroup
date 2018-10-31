using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetObject : MonoBehaviour
{
    public bool objectFound = false;

    [HideInInspector]
    public bool reset = false;

    [HideInInspector]
    public Quaternion originalRotation;
    [HideInInspector]
    public Vector3 originalPosition;
    [HideInInspector]
    public Vector3 originalScale;

    private bool countObject = false;

    private InspectItems inspectItems;
    private InspectMenuInteraction IMI;
    private Analytics analytics;
    private DetermineGameStatus DGS;

    private string sceneName;
    private string gameObjectName;

    // Use this for initialization
    void Start ()
    {
        inspectItems = GameObject.FindGameObjectWithTag("Camera").GetComponent<InspectItems>();
        analytics = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Analytics>();
        DGS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DetermineGameStatus>();
        sceneName = SceneManager.GetActiveScene().name;
        gameObjectName = gameObject.name;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ResetObjectToOriginalPosition();
        if (objectFound)
        {
            GetComponent<EditObjectGlow>().GlowColor = Color.black;
            analytics.FindObject(sceneName, gameObjectName);
            DGS.numItemsFound++;
            IMI.enabled = true;
            IMI.countObject = true;
            IMI.resetObject = gameObject.GetComponent<ResetObject>();
        }
	}

    public void ResetObjectToOriginalPosition()
    {
        if (reset)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, inspectItems.shrinkSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, originalPosition, inspectItems.itemMovementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, inspectItems.resetRotationSpeed * Time.deltaTime);
            if (transform.localScale == originalScale && transform.position == originalPosition && transform.rotation == originalRotation)
            {
                reset = false;
            }
            objectFound = true;
        }
    }
}
