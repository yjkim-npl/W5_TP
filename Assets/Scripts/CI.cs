using UnityEngine;

public class CI : MonoBehaviour
{
    PMS pMS;
    SpriteRenderer spriteRenderer;
    Animator animator;

    private void Awake()
    {
        pMS = GetComponentInParent<PMS>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Initialized();
    }
    private void Initialized()
    {
        pMS.spriteRenderer = spriteRenderer;
        pMS.cAC.animator = animator;
    }
}