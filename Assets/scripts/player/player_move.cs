using UnityEngine;
using UnityEngine.InputSystem;
public class player_move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    float movement;
    bool isGrounded, doubleJump;

    [SerializeField] float moveSpeed, jumpForce;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        //print("isGrounded: " + isGrounded);
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        //checkJump();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement * moveSpeed, rb.linearVelocity.y);

        if (movement > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        checkAnimationFloat("move", Mathf.Abs(movement));
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<float>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                doubleJump = true;
                //checkAnimationBool("is_jump", true);
            }
            else if (doubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                doubleJump = false;
                //checkAnimationBool("is_double_jump", true);
            }
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    // void checkJump()
    // {
    //     checkAnimationFloat("jump", rb.linearVelocity.y);
    //     checkAnimationFloat("double_jump", rb.linearVelocity.y);
    // }

    void checkAnimationBool(string name, bool condition)
    {
        ani.SetBool(name, condition);
    }

    void checkAnimationFloat(string name, float value)
    {
        ani.SetFloat(name, value);
    }
}
