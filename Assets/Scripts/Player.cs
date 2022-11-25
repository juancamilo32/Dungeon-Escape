using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    PlayerAnimation playerAnimation;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float movementSpeed = 400f;
    [SerializeField]
    float jumpForce = 350f;

    bool canJump = false;

    [SerializeField]
    LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed;
        FlipSprite(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce * Time.deltaTime);
            playerAnimation.Jump(true);
            canJump = false;
        }

        rigidbody2D.velocity = new Vector2(horizontalInput, rigidbody2D.velocity.y);
        playerAnimation.Move(horizontalInput);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            playerAnimation.Jump(false);
            canJump = true;
        }
    }

    void FlipSprite(float move)
    {
        if (move > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

}
