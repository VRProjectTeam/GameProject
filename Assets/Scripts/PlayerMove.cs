using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public MoveBase playMove = null;

    private void Start()
    {
        playMove = new GameObject("MoveBase").AddComponent<MoveBase>();
        playMove.SetMoveBase(GameObject.FindWithTag("Player"), MoveMode.Player, ControlMode.Player, 6.0f, 8.0f, 20.0f);
        GameObject.Find("ProjectControl").transform.GetComponent<ProjectControl>().EventCtrl.GetEvent().PlayerCtl += playMove.UseMove;
}

}
