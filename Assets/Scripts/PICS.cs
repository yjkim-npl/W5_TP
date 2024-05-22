using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PICS : BC
{
    // Start is called before the first frame update
    public void OnMove(InputValue val)
    {
        CallMoveEvent(val.Get<Vector2>().normalized);
    }

    public void OnJump(InputValue val)
    {
        CallJumpEvent();
    }

    public void OnFire(InputValue val)
    {
        Debug.Log("OnFire" + val.ToString());
    }
}
