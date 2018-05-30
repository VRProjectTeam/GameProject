using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    private CharacterProperty characterProperty;
    private SceneProperty sceneProperty;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController cc = null;
    private GameObject player;
    public Move(GameObject player, CharacterProperty characterProperty, SceneProperty sceneProperty)
    {
        this.sceneProperty = sceneProperty;
        this.characterProperty = characterProperty;
        this.player = player;
        try
        {
            cc = player.transform.GetComponent<CharacterController>();
        }
        catch
        {
            Debug.Log("未成功获取玩家控制器");
        }
    }

    public void UseMove()
    {
        if (cc.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f,
                                        Input.GetAxis("Vertical"));
            moveDirection = player.transform.TransformDirection(moveDirection);
            moveDirection *= characterProperty.MoveSpeed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = characterProperty.JumpSpeed;
            }
        }
        moveDirection.y -= sceneProperty.Gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);
    }
}
