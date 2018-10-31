using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InspectMenuInteraction : MonoBehaviour
{
    public GameObject inspectionPanel;
    public Slider pointerToButton;

    [HideInInspector]
    public bool countObject = false;

    private string sceneName;
    private string gameObjectName;

    private Analytics analytics;
    private DetermineGameStatus DGS;

    [HideInInspector]
    public ResetObject resetObject = null;

    // Use this for initialization
    void Start ()
    {
        analytics = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Analytics>();
        DGS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DetermineGameStatus>();
        sceneName = SceneManager.GetActiveScene().name;
        gameObjectName = gameObject.name;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.A))
        {
            pointerToButton.value = 0;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            pointerToButton.value = 1;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (pointerToButton.value == 1)
            {
                if (countObject)
                {
                    countObject = false;
                    resetObject.objectFound = false;
                    resetObject = null;
                    gameObject.GetComponent<InspectMenuInteraction>().enabled = false;
                    inspectionPanel.SetActive(false);
                }
            }
            else if (pointerToButton.value == 0)
            {
                if (countObject)
                {
                    GetComponent<EditObjectGlow>().GlowColor = Color.black;
                    analytics.FindObject(sceneName, gameObjectName);
                    DGS.numItemsFound++;
                    countObject = false;
                    gameObject.GetComponent<InspectMenuInteraction>().enabled = false;
                    inspectionPanel.SetActive(false);
                }
            }
        }
	}
}
