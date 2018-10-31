using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class LevelDataLoadSave : MonoBehaviour
{
    public GameObject sphereTemplate;

    private LevelData levelData = new LevelData();

    // Use this for initialization
    void Start ()
    {
        //Find Multiple Files
        string[] fileNames = System.IO.Directory.GetFiles(".", "*.lvl");

        StringBuilder sb = new StringBuilder();
        foreach (string fileName in fileNames)
        {
            sb.AppendLine(fileName);
        }
        print(sb.ToString());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void LoadLevel()
    {
        LevelData level = LevelData.LoadFromFile("default.lvl");

        foreach (GameObject existingSphere in GameObject.FindGameObjectsWithTag("MovingSphere"))
        {
            Destroy(existingSphere);
        }

        foreach (MovingSphereData movingSphere in levelData.movingSpheres)
        {
            GameObject levelSphere = GameObject.Instantiate(sphereTemplate);
            levelSphere.transform.position = movingSphere.position;
            levelSphere.GetComponent<MoveCube>().moveSpeed = movingSphere.moveSpeed;
        }
    }

    private void SaveLevel()
    {
        LevelData level = new LevelData();
        foreach (GameObject movingSphereGameObject in GameObject.FindGameObjectsWithTag("MovingSphere"))
        {
            MovingSphereData currentMovingSphere = new MovingSphereData();
            currentMovingSphere.position = movingSphereGameObject.transform.position;
            currentMovingSphere.moveSpeed = movingSphereGameObject.GetComponent<MoveCube>().moveSpeed;

            levelData.movingSpheres.Add(currentMovingSphere);
        }

        level.SaveToFile("default.lvl");

    }

    private void OnGUI()
    {
        if (GUILayout.Button("Load Level"))
        {
            LoadLevel();
        }
        if (GUILayout.Button("Save Level"))
        {
            SaveLevel();
        }
    }
}

[Serializable]
public class LevelData
{
    public List<MovingSphereData> movingSpheres = new List<MovingSphereData>();

    public void SaveToFile(string fileName)
    {
        System.IO.File.WriteAllText(fileName, JsonUtility.ToJson(this, true));
        MonoBehaviour.print(System.IO.Directory.GetCurrentDirectory());
    }

    public static LevelData LoadFromFile(string fileName)
    {
        return JsonUtility.FromJson<LevelData>(System.IO.File.ReadAllText(fileName));
    }
}

[Serializable]
public class MovingSphereData
{
    public Vector3 position;
    public float moveSpeed;
}
