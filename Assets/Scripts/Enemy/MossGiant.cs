using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{

    private Vector3 currentTarget;

    Animator animator;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
    }

    void Movement()
    {
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            spriteRenderer.flipX = false;
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            spriteRenderer.flipX = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if (transform.position == currentTarget)
        {
            animator.SetTrigger("Idle");
        }

    }

}
