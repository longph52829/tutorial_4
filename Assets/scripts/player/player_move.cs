using UnityEngine;
using UnityEngine.InputSystem;
public class player_move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    float movement;
    public bool isGrounded, doubleJump;

    [SerializeField] float moveSpeed, jumpForce, radius;
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
        checkJump();
        jump();

        /*if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                doubleJump = true;
                ani.SetBool("is_jump", true);
            }
            else if (doubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                doubleJump = false;
                ani.SetBool("is_double_jump", true);
            }
        }
        else if (isGrounded && rb.linearVelocity.y <= 0)
        {
            ani.SetBool("is_jump", false);
            ani.SetBool("is_double_jump", false);
        }*/
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

        ani.SetFloat("move", Mathf.Abs(movement));
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<float>();
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);
    }

    void checkJump()
    {
        ani.SetFloat("jump", rb.linearVelocity.y);
        ani.SetFloat("double_jump", rb.linearVelocity.y);
    }
    
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                doubleJump = true;
                ani.SetBool("is_jump", true);
            }
            else if (doubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                doubleJump = false;
                ani.SetBool("is_double_jump", true);
            }
        }
        else if (isGrounded && rb.linearVelocity.y <= 0)
        {
            ani.SetBool("is_jump", false);
            ani.SetBool("is_double_jump", false);
        }
    }
}
