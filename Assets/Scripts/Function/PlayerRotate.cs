using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRotate
{
    private EXORY xory = EXORY.XY;

    private float x = 0.0f;
    private float y = 0.0f;

    private GameObject player;
    private CharacterProperty characterProperty;

    public PlayerRotate(GameObject player, CharacterProperty characterProperty, EXORY xory)
    {
        Vector3 angles = player.transform.eulerAngles;
        x = angles.x;
        y = angles.y;
        this.xory = xory;
        this.characterProperty = characterProperty;
        this.player = player;
    }

    public void UsePlayerRotate()
    {
        switch (xory)
        {
            case EXORY.X:
                x += Input.GetAxis("Mouse X") * characterProperty.RotateSpeed * 0.02f;

                Quaternion qut1 = Quaternion.Euler(0.0f, x, 0.0f);
                player.transform.rotation = qut1;
                break;
            case EXORY.Y:
                y -= Input.GetAxis("Mouse Y") * characterProperty.RotateSpeed * 0.02f;

                y = ClampAngle(y, characterProperty.YMinLimit, characterProperty.YMaxLimit);
                Quaternion qut2 = Quaternion.Euler(y, 0.0f, 0.0f);
                player.transform.rotation = qut2;
                break;
            case EXORY.XY:
                x += Input.GetAxis("Mouse X") * characterProperty.RotateSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * characterProperty.RotateSpeed * 0.02f;

                y = ClampAngle(y, characterProperty.YMinLimit, characterProperty.YMaxLimit);
                Quaternion qut3 = Quaternion.Euler(y, x, 0.0f);
                player.transform.rotation = qut3;
                break;
        }
    }
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360.0f)
        {
            angle += 360.0f;
        }
        if (angle > 360.0f)
        {
            angle -= 360.0f;
        }

        return Mathf.Clamp(angle, min, max);
    }
}
