using System;
using UnityEngine;

public class BC : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnJumpEvent;

    public void CallMoveEvent(Vector2 v2)
    {
        OnMoveEvent?.Invoke(v2);
    }

    public void CallJumpEvent(Vector2 v2)
    {
        OnJumpEvent?.Invoke(v2);
    }
}