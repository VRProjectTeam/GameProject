using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotateLock
{
    NULL,
    X,
    Y,
    Z,
    XY,
    XZ,
    YZ,
    XYZ
}
public enum RotateControlMode
{
    NULL,
    Player,
    Other
}
public class RotateBase : MonoBehaviour
{
    public RotateLock rotateLock = RotateLock.NULL;
    public RotateControlMode rotateControlMode = RotateControlMode.NULL;

    [SerializeField]
    private Vector3 rotateDirectio=Vector3.zero;
    [SerializeField]
    private GameObject Instance = null;

    [SerializeField]
    private float yMinLimit = 0.0f;
    [SerializeField]
    private float yMaxLimit = 0.0f;

    [SerializeField]
    private float xMinLimit = 0.0f;
    [SerializeField]
    private float xMaxLimit = 0.0f;

    [SerializeField]
    private float zMinLimit = 0.0f;
    [SerializeField]
    private float zMaxLimit = 0.0f;

    [SerializeField]
    private float x = 0.0f;
    [SerializeField]
    private float y = 0.0f;
    [SerializeField]
    private float z = 0.0f;

    [SerializeField]
    private float xSpeed = 0.0f;
    [SerializeField]
    private float ySpeed = 0.0f;
    [SerializeField]
    private float zSpeed = 0.0f;

    public void SetRotate(GameObject Instance, RotateControlMode rotateControlMode, RotateLock rotateLock)
    {
        Vector3 angles = this.transform.eulerAngles;
        this.rotateControlMode = rotateControlMode;
        this.rotateLock = rotateLock;
        this.Instance = Instance;

        x = angles.x;
        y = angles.y;
        z = angles.z;
    }
    public void SetRotate(GameObject Instance, RotateControlMode rotateControlMode, RotateLock rotateLock ,float xMinLimit = -90.0f, float xMaxLimit = 90.0f, float yMinLimit = -90.0f, float yMaxLimit = 90.0f, float zMinLimit = -90.0f, float zMaxLimit = 90.0f, float xSpeed = 100.0f, float ySpeed = 100.0f, float zSpeed = 100.0f)
    {
        SetRotate(Instance, rotateControlMode, rotateLock);
        SetValue(xMinLimit, xMaxLimit, yMinLimit, yMaxLimit, zMinLimit, zMaxLimit, xSpeed, ySpeed);
    }
    public void UseRotate()
    {
        if (rotateControlMode == RotateControlMode.NULL)
        {
            Debug.Log("未配置旋转模式");
        }
        else
        {
            if (rotateControlMode == RotateControlMode.Other)
            {
                UseRotate(rotateDirectio, xMinLimit, xMaxLimit, yMinLimit, yMaxLimit, zMinLimit, zMaxLimit, xSpeed, ySpeed, zSpeed);
            }
            if (rotateControlMode == RotateControlMode.Player)
            {
                UseRotate(xMinLimit, xMaxLimit, yMinLimit, yMaxLimit, xSpeed, ySpeed);
            }
        }
    }
    public void UseRotate(float xMinLimit, float xMaxLimit, float yMinLimit, float yMaxLimit, float xSpeed, float ySpeed)//X,Y
    {
        //Use X,Y,for Limiting the axial range ， Default +-90 , axial Speed Default 100.0f
        SetValue(xMinLimit, xMaxLimit, yMinLimit, yMaxLimit,0.0f, 0.0f, xSpeed, ySpeed);
        if (rotateControlMode == RotateControlMode.NULL)
        {
            Debug.Log("未配置旋转模式");
        }
        else
        {
            if (rotateControlMode == RotateControlMode.Player)
            {
                switch (rotateLock)
                {
                    case RotateLock.X:
                        x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                        Quaternion qut1 = Quaternion.Euler(0.0f, x, 0.0f);
                        Instance.transform.rotation = qut1;
                        break;
                    case RotateLock.Y:
                        y += Input.GetAxis("Mouse Y") * xSpeed * 0.02f;
                        Quaternion qut2 = Quaternion.Euler(y, 0.0f, 0.0f);
                        Instance.transform.rotation = qut2;
                        break;
                    case RotateLock.XY:
                        x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                        y = ClampAngle(y, yMinLimit, yMaxLimit);
                        Quaternion qut3 = Quaternion.Euler(y, x, 0.0f);
                        Instance.transform.rotation = qut3;
                        break;
                    default:
                        Debug.Log("鼠标操作未找到全部轴向");
                        break;
                }
            }
        }
    }
    public void UseRotate(Vector3 Rotation, float xMinLimit, float xMaxLimit, float yMinLimit, float yMaxLimit, float zMinLimit, float zMaxLimit, float xSpeed, float ySpeed, float zSpeed)//X,Y,Z
    {
        //Use X,Y,Z for Limiting the axial range ， Default +-90 , axial Speed Default 100.0f
        SetValue(xMinLimit, xMaxLimit, yMinLimit, yMaxLimit, zMinLimit, zMaxLimit, xSpeed, ySpeed);
        if (rotateControlMode == RotateControlMode.NULL)
        {
            Debug.Log("未配置旋转模式");
        }
        else
        {
            if (rotateControlMode == RotateControlMode.Other)
            {
                switch (rotateLock)
                {
                    case RotateLock.X:
                        operAndSetX(Rotation);
                        break;
                    case RotateLock.Y:
                        operAndSetY(Rotation);
                        break;
                    case RotateLock.Z:
                        operAndSetZ(Rotation);
                        break;
                    case RotateLock.XY:
                        operAndSetX(Rotation);
                        operAndSetY(Rotation);
                        break;
                    case RotateLock.XZ:
                        operAndSetX(Rotation);
                        operAndSetZ(Rotation);
                        break;
                    case RotateLock.YZ:
                        operAndSetY(Rotation);
                        operAndSetZ(Rotation);
                        break;
                    case RotateLock.XYZ:
                        operAndSetX(Rotation);
                        operAndSetY(Rotation);
                        operAndSetZ(Rotation);
                        break;
                }
            }
        }
    }
    private float ClampAngle(float angle, float min, float max)
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
    private void SetValue(float xMinLimit = -90.0f, float xMaxLimit = 90.0f, float yMinLimit = -90.0f, float yMaxLimit = 90.0f, float zMinLimit = -90.0f, float zMaxLimit = 90.0f, float xSpeed = 100.0f, float ySpeed = 100.0f, float zSpeed = 100.0f)
    {
        this.xMinLimit = xMinLimit;
        this.xMaxLimit = xMaxLimit;

        this.yMinLimit = yMinLimit;
        this.yMaxLimit = yMaxLimit;

        this.zMinLimit = zMinLimit;
        this.zMaxLimit = zMaxLimit;

        this.xSpeed = xSpeed;
        this.ySpeed = ySpeed;
        this.zSpeed = zSpeed;
    }
    private void operAndSetX(Vector3 X)
    {
        x += X.x * xSpeed * 0.02f;
        Quaternion qut = Quaternion.Euler(0.0f, x, 0.0f);
        Instance.transform.rotation = qut;
    }
    private void operAndSetY(Vector3 Y)
    {
        y += Y.y * xSpeed * 0.02f;
        Quaternion qut = Quaternion.Euler(y, 0.0f, 0.0f);
        Instance.transform.rotation = qut;
    }
    private void operAndSetZ(Vector3 Z)
    {
        z += Z.z * xSpeed * 0.02f;
        Quaternion qut = Quaternion.Euler(0.0f, 0.0f, z);
        Instance.transform.rotation = qut;
    }
}
