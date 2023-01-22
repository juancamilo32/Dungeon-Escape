using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;
    protected Vector3 currentTarget;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected bool gotHit = false;
    protected Player player;
    protected bool isDead = false;
    [SerializeField]
    protected GameObject diamondPrefab;

    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Init();
    }

    public void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !animator.GetBool("InCombat"))
        {
            return;
        }

        if (!isDead)
        {
            Movement();
        }

    }

    public virtual void Movement()
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

        if (!gotHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        CheckDistanceToPlayer();

        if (transform.position == currentTarget)
        {
            animator.SetTrigger("Idle");
        }

        FlipSpriteOnCombat();

    }

    void CheckDistanceToPlayer()
    {
        float distance = Vector3.Distance(player.transform.localPosition, transform.localPosition);
        if (distance > 2f)
        {
            gotHit = false;
            animator.SetBool("InCombat", false);
        }
    }

    void FlipSpriteOnCombat()
    {
        Vector3 direction = player.transform.localPosition - transform.localPosition;
        if (animator.GetBool("InCombat"))
        {
            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

}
