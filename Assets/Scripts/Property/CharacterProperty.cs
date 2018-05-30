using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EXORY
{
    X,
    Y,
    XY
}
public abstract class CharacterProperty
{
    protected float moveSpeed;
    protected float jumpSpeed;

    protected float rotateSpeed;

    protected float yMinLimit;
    protected float yMaxLimit;

    public virtual float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    public virtual float JumpSpeed
    {
        get { return jumpSpeed; }
        set { jumpSpeed = value; }
    }
    public virtual float RotateSpeed
    {
        get { return rotateSpeed; }
        set { rotateSpeed = value; }
    }

    public virtual float YMinLimit
    {
        get { return yMinLimit; }
        set { yMinLimit = value; }
    }
    public virtual float YMaxLimit
    {
        get { return yMaxLimit; }
        set { yMaxLimit = value; }
    }
}
