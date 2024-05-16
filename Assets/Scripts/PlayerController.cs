using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    public float speed;
    public float jumpPower;

    int jumpCnt;

    // Start is called before the first frame update
    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        if (!spriteRenderer) spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        // �¿� �̵�
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0).normalized * speed * Time.deltaTime;
        //�̵� �������� �ٶ󺸱�
        if (Input.GetKey(KeyCode.A))
            spriteRenderer.flipX = true;
        else if (Input.GetKey(KeyCode.D))
            spriteRenderer.flipX = false;

        //���� ���� ����
        if (Input.GetKeyDown(KeyCode.W) && jumpCnt < 2)
        {
            //���� ���� �յ�ȭ�� ���� ���ν�Ƽ �ʱ�ȭ
            rb.velocity = Vector3.zero;
            //������ ���� ��Ŀ����
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            jumpCnt++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Ground":
                jumpCnt = 0;
                break;
        }
    }
}
