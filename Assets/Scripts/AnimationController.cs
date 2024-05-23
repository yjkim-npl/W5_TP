using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    protected BaseController controller;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<BaseController>();
    }

    protected virtual void Start()
    {
        
    }
}