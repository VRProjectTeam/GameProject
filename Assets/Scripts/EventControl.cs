using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventControl : MonoBehaviour
{
     private DelegateControl DC;
    private void Awake()
    {
        DC = new GameObject("EventControl").AddComponent<DelegateControl>();
    }
    public DelegateControl GetEvent()
    {
        return DC;
    }

}
