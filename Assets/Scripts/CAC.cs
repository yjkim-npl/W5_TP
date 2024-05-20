using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CAC : AC
{
    private static readonly int isMove = Animator.StringToHash("isMove");
    private static readonly int IsHit = Animator.StringToHash("isHit");
    private static readonly int isJump = Animator.StringToHash("isJump");
    private static readonly int IsAttack = Animator.StringToHash("isAttack");

    private readonly float magnituteThreshold = 0.5f;

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnJumpEvent += Jump;
    }

    private void Jump(Vector2 obj)
    {
        animator.SetBool(isJump, obj.magnitude > magnituteThreshold);
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(isMove, obj.magnitude > magnituteThreshold);
    }

    private void Attacking()
    {
        animator.SetBool(IsAttack, true);
    }

    // 아직 피격부분은 없지만 곧 할 것이기 때문에 일단 둡니다.
    private void Hit()
    {
        animator.SetBool(IsHit, true);
    }

    // 아직 피격부분은 없지만 곧 할 것이기 때문에 일단 둡니다.
    private void InvincibilityEnd()
    {
        animator.SetBool(IsHit, false);
    }
}