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

        Vector3 direction = player.transform.localPosition - transform.localPosition;
        Debug.Log(direction.x);
        if (animator.GetBool("InCombat"))
        {
            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    public void TakeDamage()
    {
        Health--;
        animator.SetTrigger("Hit");
        gotHit = true;
        animator.SetBool("InCombat", true);
        if (Health < 1)
        {
            Destroy(gameObject);
        }
    }

}
