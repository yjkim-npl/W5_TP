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
    public void OnFire(InputValue value)
    {
        Debug.Log("OnFire" + value.ToString());
    }
}
