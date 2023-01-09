using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    [SerializeField]
    GameObject acidPrefab;

    public void TakeDamage()
    {
        Health--;
        if (Health < 1)
        {
            isDead = true;
            collider.enabled = false;
            animator.SetTrigger("Death");
        }
    }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {

    }

    public void Attack()
    {
        Instantiate(acidPrefab, transform.position, Quaternion.identity);
    }

}
