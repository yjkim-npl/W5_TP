using UnityEngine;

public class CharacterInform : MonoBehaviour
{
    PlayerMovementSingle pMS;
    SpriteRenderer spriteRenderer;
    Animator animator;

    private void Awake()
    {
        pMS = GetComponentInParent<PlayerMovementSingle>();
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