using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    Animator animator;
    Animator swordAnimator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        swordAnimator = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(float move)
    {
        animator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool isJumping)
    {
        animator.SetBool("Jumping", isJumping);
    }

    public void Attack()
    {
        animator.SetTrigger("Attacking");
        swordAnimator.SetTrigger("Attacking");
    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }

}
