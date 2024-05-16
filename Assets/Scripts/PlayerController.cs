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
        // 좌우 이동
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0).normalized * speed * Time.deltaTime;
        //이동 방향으로 바라보기
        if (Input.GetKey(KeyCode.A))
            spriteRenderer.flipX = true;
        else if (Input.GetKey(KeyCode.D))
            spriteRenderer.flipX = false;

        //점프 더블 점프
        if (Input.GetKeyDown(KeyCode.W) && jumpCnt < 2)
        {
            //점프 높이 균등화를 위한 벨로시티 초기화
            rb.velocity = Vector3.zero;
            //실질적 점프 메커니즘
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
