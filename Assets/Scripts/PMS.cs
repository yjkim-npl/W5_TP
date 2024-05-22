using System;
using UnityEngine;

public class PMS : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public CAC cAC;
    private PICS ctrl;
    private Rigidbody2D rb2d;
    private Vector2 mDir = Vector2.zero;
    private bool isJumping = false;
    private int jumpCnt = 0;

    [SerializeField] private float jumpPower;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private GameObject[] characters;

    private void Awake()
    {
        cAC = GetComponent<CAC>();
        ctrl = GetComponent<PICS>();
        rb2d = GetComponent<Rigidbody2D>();
        ctrl.OnMoveEvent += Move;
        ctrl.OnJumpEvent += ApplyJumpment;
    }

    private void Start()
    {
        if(DM.instance.GetMode() == 1)
        characters[DM.instance.GetP1Chara()-1].SetActive(true);

        else if(DM.instance.GetMode() == 2)
        {
            switch (gameObject.name)
            {
                case "P1":
                    characters[DM.instance.GetP1Chara()-1].SetActive(true);
                    break;
                case "P2":
                    characters[DM.instance.GetP2Chara()-1].SetActive(true);
                    break;

            }
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement(mDir);
    }

    private void Move(Vector2 v2)
    {
        mDir = v2;
    }

    private void JumpTime()
    {
        isJumping = false;
    }

    private void ApplyMovement(Vector2 v2)
    {
        if (v2.x > 0)
            spriteRenderer.flipX = false;
        else if (v2.x < 0)
            spriteRenderer.flipX = true;
        v2 = speed * v2;
        rb2d.velocity = new Vector2(v2.x, rb2d.velocity.y);
    }

    private void ApplyJumpment()
    {
        if (!isJumping)
        {
            if (jumpCnt < 2)
            {
                //점프 높이 균등화를 위한 벨로시티 초기화
                rb2d.velocity = Vector3.zero;
                //실질적 점프 메커니즘
                cAC.Jump(true);
                rb2d.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
                isJumping = true;
                Invoke("JumpTime", 0.1f);
                jumpCnt++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.name)
        {
            case "Ground":
            case "Rock":
            case "P1":
            case "P2":
            case "Collision":
                cAC.Jump(false);
                jumpCnt = 0;
                break;
            default:
                break;
        }
    }
}