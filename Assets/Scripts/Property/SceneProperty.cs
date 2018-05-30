using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneProperty
{
    protected float gravity;

    public virtual float Gravity
    {
        get { return gravity; }
        set { gravity = value; }
    }
}
