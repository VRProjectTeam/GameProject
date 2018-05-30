using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private SceneProperty sceneProperty;

    private void Awake()
    {
        sceneProperty = new MainSceneProperty();
        SendScene();
    }

    private void SendScene()
    {
        try
        {
            PlayerController p = GameObject.FindWithTag("Controller").GetComponent<PlayerController>();
            p.SetSceneProperty = sceneProperty;
        }
        catch
        {
            Debug.Log("未能成功获取玩家控制器");
        }
    }
}
