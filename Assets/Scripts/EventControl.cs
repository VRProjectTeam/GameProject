﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventControl : MonoBehaviour
{
     private DelegateControl DC;
    private void Awake()
    {
        DC = new GameObject("DelegateControl").AddComponent<DelegateControl>();
    }
    public DelegateControl GetEvent()
    {
        return DC;
    }

}
