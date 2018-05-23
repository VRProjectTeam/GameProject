using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DelegateControl : MonoBehaviour
{

    public event Action PlayerCtl;
    private void PlayerCtlRun()
    {
        if (this.PlayerCtl != null)
        {
            this.PlayerCtl();
        }
    }

    void Update()
    {
        PlayerCtlRun();
    }
}
