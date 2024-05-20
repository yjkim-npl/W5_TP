using System;
using UnityEngine;

public class PMS : MonoBehaviour
{
    private PICS ctrl;
    private Rigidbody2D rb2d;
    private Vector2 mDir = Vector2.zero;
    private bool isJumping = false;
    private int jumpCnt = 0;

    [SerializeField] private float jumpPower;
    [SerializeField] private float speed = 5.0f;

    private void Awake()
    {
        ctrl = GetComponent<PICS>();
        rb2d = GetComponent<Rigidbody2D>();
        ctrl.OnMoveEvent += Move;
        ctrl.OnJumpEvent += Jump;
    }

    private void FixedUpdate()
    {
        ApplyMovement(mDir);
        ApplyJumpment(mDir);
    }

    private void Move(Vector2 v2)
    {
        mDir = v2;
    }

    private void Jump(Vector2 v2)
    {
        mDir = v2;
    }

    private void JumpTime()
    {
        isJumping = false;
    }

    private void ApplyMovement(Vector2 v2)
    {
        v2 = speed * v2;
        rb2d.velocity = new Vector2(v2.x, rb2d.velocity.y);
    }

    private void ApplyJumpment(Vector2 v2)
    {
        if (v2.y > 0)
        {
            if (!isJumping)
            {
                if (jumpCnt < 2)
                {
                    //점프 높이 균등화를 위한 벨로시티 초기화
                    rb2d.velocity = Vector3.zero;
                    //실질적 점프 메커니즘
                    rb2d.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
                    isJumping = true;
                    Invoke("JumpTime", 0.2f);
                    jumpCnt++;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.name)
        {
            case "Collision":
            case "Rock":
            case "P1":
            case "P2":
            case "Ground":
                jumpCnt = 0;
                break;
            default:
                break;
        }
    }
}
