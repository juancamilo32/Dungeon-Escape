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

    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        Debug.Log(animator.name);
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
        Movement();
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

}
