using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{

    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }

    public void TakeDamage()
    {
        Health--;
        animator.SetTrigger("Hit");
        gotHit = true;
        animator.SetBool("InCombat", true);
        if (Health < 1)
        {
            isDead = true;
            collider.enabled = false;
            animator.SetTrigger("Death");
        }
    }

}
