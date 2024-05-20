using UnityEngine;

public class AC : MonoBehaviour
{
    protected Animator animator;
    protected BC controller;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<BC>();
    }

    protected virtual void Start()
    {
        
    }
}