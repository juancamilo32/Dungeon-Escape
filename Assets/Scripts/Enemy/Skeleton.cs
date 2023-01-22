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
        if (isDead)
        {
            return;
        }
        Health--;
        animator.SetTrigger("Hit");
        gotHit = true;
        animator.SetBool("InCombat", true);
        if (Health < 1)
        {
            isDead = true;
            animator.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            diamond.GetComponent<Diamond>().value = base.gems;
        }
    }

}
