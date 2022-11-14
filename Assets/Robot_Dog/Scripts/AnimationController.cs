using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rigidBody;
    public bool sleep, dance;
    public MoveToPoint mtp;

    void Awake()
    {
        if(animator == null)
            animator = GetComponent<Animator>();
        if(rigidBody == null)
            rigidBody = GetComponent<Rigidbody>();
        if(mtp == null)
            mtp = GetComponent<MoveToPoint>();
        Sleep();
    }

    void Update()
    {
        if(dance == false && sleep == false)
            animator.SetFloat("speed", rigidBody.velocity.magnitude);
    }

    public void Dance()
    {
        animator.SetBool("dance", true);
        animator.SetBool("sleep", false);
        mtp.walk = false;
    }

    public void Sleep()
    {
        animator.SetBool("sleep", true);
        animator.SetBool("dance", false);
        mtp.walk = false;
    }

    public void Wake()
    {
        animator.SetBool("sleep", false);
        animator.SetBool("dance", false);
        mtp.walk = false;
    }
    public void Move()
    {
        animator.SetBool("sleep", false);
        animator.SetBool("dance", false);
        mtp.walk = true;
    }
}
