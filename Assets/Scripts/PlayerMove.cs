using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public MoveBase playMove = null;
    public RotateBase rotateBase = null;
    private ProjectControl projectControl = null;
    private void Start()
    {
        projectControl = GameObject.Find("ProjectControl").transform.GetComponent<ProjectControl>();

        playMove = this.gameObject.AddComponent<MoveBase>();
        playMove.SetMoveBase(GameObject.FindWithTag("Player"), MoveMode.Player, MoveControlMode.Player, 6.0f, 8.0f, 20.0f);
        projectControl.EventCtrl.GetEvent().PlayerCtl += playMove.UseMove;

        rotateBase = this.gameObject.AddComponent<RotateBase>();
        rotateBase.SetRotate(GameObject.FindWithTag("Player"), RotateControlMode.Player, RotateLock.XY, 360.0f, 360.0f, -20.0f, 60.0f, 0.0f, 0.0f);
        projectControl.EventCtrl.GetEvent().PlayerCtl += rotateBase.UseRotate;


}

}
