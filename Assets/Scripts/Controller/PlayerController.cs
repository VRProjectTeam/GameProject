using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterProperty characterProperty;
    private SceneProperty sceneProperty;

    [SerializeField]
    private GameObject player;

    private Move move;
    private PlayerRotate playerRotate;

    public SceneProperty SetSceneProperty
    {
        set{ sceneProperty = value; }
    }
    private void Start()
    {
        characterProperty = new PlayerProperty();
        try
        {
            player = GameObject.FindWithTag("Player");
            move = new Move(player, characterProperty, sceneProperty);
            playerRotate = new PlayerRotate(player, characterProperty, EXORY.XY);
        }
        catch
        {
            Debug.Log("未能找到玩家");
        }
    }
    private void Update()
    {
        try
        {
            move.UseMove();
        }
        catch
        {
            Debug.Log("无法移动");
        }
        try
        {
            playerRotate.UsePlayerRotate();
        }
        catch
        {
            Debug.Log("无法旋转视角");
        }
    }
}
