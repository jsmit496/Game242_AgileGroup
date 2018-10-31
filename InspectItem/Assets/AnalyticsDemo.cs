using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsDemo : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        IDictionary<string, object> additionalData = new Dictionary<string, object>();
        additionalData.Add("sample number", 23);

        AnalyticsEvent.GameStart(additionalData);
        AnalyticsEvent.Custom("custom_demo_event", additionalData);

        //example
        IDictionary<string, object> findData = new Dictionary<string, object>();
        findData.Add("level", "levelName");
        findData.Add("object_id", 1);
        findData.Add("time", (int)Time.timeSinceLevelLoad);
        AnalyticsEvent.Custom("obj_found", findData);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}