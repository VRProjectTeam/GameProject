using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectControl : MonoBehaviour
{
    public EventControl EventCtrl;
    private void Awake()
    {
        EventCtrl = new GameObject("EventComtrol").AddComponent<EventControl>();
    }
    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
