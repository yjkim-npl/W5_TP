using System;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnJumpEvent;


    public void CallMoveEvent(Vector2 v2)
    {
        OnMoveEvent?.Invoke(v2);
    }

    public void CallJumpEvent()
    {
        OnJumpEvent?.Invoke();
    }
}