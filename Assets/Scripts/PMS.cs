using System;
using UnityEngine;

public class PMS : MonoBehaviour
{
    private PICS ctrl;
    private Rigidbody2D rb2d;
    private Vector2 mDir;
    [SerializeField] private float speed = 3.0f;

    private void Awake()
    {
        ctrl = GetComponent<PICS>();
        rb2d = GetComponent<Rigidbody2D>();
        ctrl.OnMoveEvent += Move;
    }


    private void FixedUpdate()
    {
        ApplyMovement(mDir);
    }
    private void Move(Vector2 v2)
    {
        mDir = v2;
    }
    private void ApplyMovement(Vector2 v2)
    {
        rb2d.velocity = speed*v2;
    }
}
