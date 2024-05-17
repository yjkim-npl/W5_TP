using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TotalMovement : MonoBehaviour
{
    private TotalController movementController;
    private Rigidbody2D movementRigidbody;

    private Vector2 movementDirection = Vector2.zero;

    public float jumpPower;

    public bool jumping = false;

    int jumpCnt;
    private void Awake()
    {
        // 같은 게임오브젝트의 TopDownController, Rigidbody를 가져올 것 
        movementController = GetComponent<TotalController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // OnMoveEvent에 Move를 호출하라고 등록함
        movementController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        // 물리 업데이트에서 움직임 적용
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        // 이동방향만 정해두고 실제로 움직이지는 않음.
        // 움직이는 것은 물리 업데이트에서 진행(rigidbody가 물리니까)
        movementDirection = direction;
        //Debug.Log(direction);
    }

    private void Jump()
    {
        if (!jumping)
        {
            if (jumpCnt < 2)
            {
                //점프 높이 균등화를 위한 벨로시티 초기화
                movementRigidbody.velocity = Vector3.zero;
                //실질적 점프 메커니즘
                movementRigidbody.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
                jumping = true;
                Invoke("JumpTime", 0.2f);
                jumpCnt++;
            }
        }
    }

    private void JumpTime()
    {
        jumping = false;
    }

    private void ApplyMovement(Vector2 direction)
    {
        if (direction.y > 0)
        {
            Jump();
        }

        direction = direction * 5;

        movementRigidbody.velocity = new Vector2(direction.x, movementRigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Collision":
                jumpCnt = 0;
                break;
            default:
                break;
        }
    }
}