using UnityEngine;
using UnityEngine.InputSystem;
public class player_move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    float movement;
    public bool isGrounded, isJumping, doubleJump;

    [SerializeField] float moveSpeed, jumpForce;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement * moveSpeed, rb.linearVelocity.y);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<float>();
        print(movement);
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            isJumping = true;
        }
        else if (value.isPressed && !isGrounded && doubleJump)
        {
            isJumping = true;
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (isGrounded)
        {
            doubleJump = true;
        }

        if (isJumping && (doubleJump || isGrounded))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = false;

            if (!isGrounded && doubleJump)
            {
                doubleJump = false;
            }
        }
    }
}
