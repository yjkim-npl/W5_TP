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
        // ���� ���ӿ�����Ʈ�� TopDownController, Rigidbody�� ������ �� 
        movementController = GetComponent<TotalController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // OnMoveEvent�� Move�� ȣ���϶�� �����
        movementController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        // ���� ������Ʈ���� ������ ����
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        // �̵����⸸ ���صΰ� ������ ���������� ����.
        // �����̴� ���� ���� ������Ʈ���� ����(rigidbody�� �����ϱ�)
        movementDirection = direction;
        //Debug.Log(direction);
    }

    private void Jump()
    {
        if (!jumping)
        {
            if (jumpCnt < 2)
            {
                //���� ���� �յ�ȭ�� ���� ���ν�Ƽ �ʱ�ȭ
                movementRigidbody.velocity = Vector3.zero;
                //������ ���� ��Ŀ����
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