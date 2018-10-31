using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Analytics : MonoBehaviour
{

    private void Start()
    {

    }

    public void FindObject(string levelName, string objectName)
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        data.Add("level", levelName);
        data.Add("object_name", objectName);
        data.Add("time", (int)Time.timeSinceLevelLoad);
        AnalyticsEvent.Custom("find_object", data);
    }

    public void FoundAllObjects(bool foundAll)
    {
        if (foundAll)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("time", (int)Time.timeSinceLevelLoad);
            AnalyticsEvent.LevelComplete(SceneManager.GetActiveScene().name, data);
        }
        else if (!foundAll)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("time", (int)Time.timeSinceLevelLoad);
            AnalyticsEvent.LevelQuit(SceneManager.GetActiveScene().name, data);
        }
    }
}
