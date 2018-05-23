using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveMode
{
    NULL,
    Player,
    StaticObject
}
public enum PowerMode
{
    NULL,
    Force,
    Acceleration,
    Impulse,
    VelocityChange
}
public class MoveBase : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private float jumpSpeed = 0.0f;
    [SerializeField]
    private float gravity = 0.0f;
    [SerializeField]
    private float power = 0.0f;

    [SerializeField]
    private GameObject instance = null;

    [SerializeField]
    private Vector3 powerDirection = Vector3.zero;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

    public MoveMode moveMode = MoveMode.NULL;
    public PowerMode powerMode = PowerMode.NULL;

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    public float JumpSpeed
    {
        get { return jumpSpeed; }
        set { jumpSpeed = value; }
    }
    public float Gravity
    {
        get { return gravity; }
        set { gravity = value; }
    }
    public GameObject Instance
    {
        get { return instance; }
        set { instance = value; }
    }
    public Vector3 PowerDirection
    {
        get { return powerDirection; }
        set { powerDirection = value; }
    }
    public float Power
    {
        get { return power; }
        set { power = value; }
    }

    public void SetMoveBase(GameObject instance, MoveMode moveMode, float moveSpeed, float jumpSpeed, float gravity)
    {
        this.moveMode = moveMode;
        this.moveSpeed = moveSpeed;
        this.jumpSpeed = jumpSpeed;
        this.gravity = gravity;
        this.instance = instance;

        IsMoveMode(moveMode);
    }
    public void SetMoveBase(GameObject instance, MoveMode moveMode, Vector3 powerDirection, float power)
    {
        this.instance = instance;
        this.powerDirection = powerDirection;
        this.power = power;

        IsMoveMode(moveMode);
    }
    public void SetMoveBase(GameObject instance, MoveMode moveMode)
    {
        this.instance = instance;

        IsMoveMode(moveMode);
    }

    private void IsMoveMode(MoveMode moveMode)
    {
        if (moveMode == MoveMode.NULL)
        {
            Debug.Log("系统未能识别该实例模式");
        }
        else
        {
            if (moveMode == MoveMode.Player)
            {
                try
                {
                    if (!instance.transform.GetComponent<CharacterController>())
                    {
                        instance.AddComponent<CharacterController>();
                    }
                }
                catch
                {
                    Debug.Log("未能加载玩家控制器");
                }
            }
            if (moveMode == MoveMode.StaticObject)
            {
                try
                {
                    if (!instance.transform.GetComponent<Rigidbody>())
                    {
                        instance.AddComponent<Rigidbody>();
                    }
                }
                catch
                {
                    Debug.Log("未能加载刚体组件");
                }
            }
        }
    }
    public void UsePower(PowerMode powerMode)
    {
        UsePower(powerMode, powerDirection, power);
    }
    public void UsePower(PowerMode powerMode, Vector3 powerDirection, float power)
    {
        if (powerMode == PowerMode.NULL)
        {
            Debug.Log("未设置力的模式");
        }
        else
        {
            if (moveMode == MoveMode.StaticObject)
            {
                try
                {
                    switch (powerMode)
                    {
                        case PowerMode.Force:
                            Instance.transform.GetComponent<Rigidbody>().AddForce(powerDirection * power, ForceMode.Force);
                            break;
                        case PowerMode.Acceleration:
                            Instance.transform.GetComponent<Rigidbody>().AddForce(powerDirection * power, ForceMode.Acceleration);
                            break;
                        case PowerMode.Impulse:
                            Instance.transform.GetComponent<Rigidbody>().AddForce(powerDirection * power, ForceMode.Impulse);
                            break;
                        case PowerMode.VelocityChange:
                            Instance.transform.GetComponent<Rigidbody>().AddForce(powerDirection * power, ForceMode.VelocityChange);
                            break;
                    }
                }
                catch
                {
                    Debug.Log("未能成功加载力");
                }
            }
            else
            {
                Debug.Log("非刚体不能加载力");
            }
        }
    }
    public void UseMove()
    {
        UseMove(moveSpeed, jumpSpeed, gravity);
    }
    public void UseMove(float moveSpeed, float jumpSpeed, float gravity)
    {
        if (moveMode == MoveMode.StaticObject)
        {
            Debug.Log("不能使用控制器控制非控制器对象");
        }
        else
        {
            if (instance.transform.GetComponent<CharacterController>().isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = instance.transform.TransformDirection(moveDirection);
                moveDirection *= moveSpeed;
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
            }
            moveDirection.y -= gravity * Time.deltaTime;
            instance.transform.GetComponent<CharacterController>().Move(moveDirection * Time.deltaTime);
        }
    }
}
