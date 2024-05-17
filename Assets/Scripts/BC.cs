using System;
using UnityEngine;

public class BC : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;

    public void CallMoveEvent(Vector2 v2)
    {
        OnMoveEvent?.Invoke(v2);
    }
}