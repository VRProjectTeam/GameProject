using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : CharacterProperty
{
    public PlayerProperty()
    {
        moveSpeed = 6.0f;
        jumpSpeed = 8.0f;
        rotateSpeed = 100.0f;
        yMinLimit = -20.0f;
        yMaxLimit = 60.0f;
    }
    public override float MoveSpeed
    {
        get { return moveSpeed; }
        set { if (value > 0) moveSpeed = value; }
    }
    public override float JumpSpeed
    {
        get { return jumpSpeed; }
        set { if (value > 0) jumpSpeed = value; }
    }
}
