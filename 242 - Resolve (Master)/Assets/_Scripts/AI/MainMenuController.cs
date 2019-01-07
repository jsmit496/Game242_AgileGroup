using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string gameSceneName;
    public string creditsSceneName;
    public string mainMenuSceneName;
    public float transformSpeed = 10f;
    public float levelRotationSpeed = 10f;

    public GameObject[] mainMenuObjects;
    public GameObject[] loadMenuObjects;
    public Transform level;
    public Transform levelCamera;
    public Transform defaultCameraSpot;
    public Transform overheadCameraSpot;

    bool rotate = true;
    Vector3 levelStartRotation;

    public void Start()
    {
        levelStartRotation = level.localEulerAngles;
    }

    public void Update()
    {
        if (rotate)
        {
            levelCamera.position = Vector3.Lerp(levelCamera.position, defaultCameraSpot.position, transformSpeed * Time.deltaTime);
            levelCamera.localEulerAngles = Vector3.Lerp(levelCamera.localEulerAngles, defaultCameraSpot.localEulerAngles, transformSpeed * Time.deltaTime);
            //level.Rotate(Vector3.up, levelRotationSpeed * Time.deltaTime);
        }
        else if (!rotate)
        {
            levelCamera.position = Vector3.Lerp(levelCamera.position, overheadCameraSpot.position, transformSpeed * Time.deltaTime);
            levelCamera.localEulerAngles = Vector3.Lerp(levelCamera.localEulerAngles, overheadCameraSpot.localEulerAngles, transformSpeed * Time.deltaTime);

            //level.localEulerAngles = Vector3.Lerp(level.localEulerAngles, levelStartRotation, levelRotationSpeed * Time.deltaTime);
        }
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene(creditsSceneName);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void SetCameraOverhead()
    {
        rotate = false;
        for (int i = 0; i < mainMenuObjects.Length; i++)
        {
            mainMenuObjects[i].SetActive(false);
        }
        for (int i = 0; i < loadMenuObjects.Length; i++)
        {
            loadMenuObjects[i].SetActive(true);
        }
    }

    public void SetCameraDefault()
    {
        rotate = true;
        for (int i = 0; i < mainMenuObjects.Length; i++)
        {
            mainMenuObjects[i].SetActive(true);
        }
        for (int i = 0; i < loadMenuObjects.Length; i++)
        {
            loadMenuObjects[i].SetActive(false);
        }
    }
}
