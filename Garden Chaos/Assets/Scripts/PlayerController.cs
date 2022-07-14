using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public float maxSpeed;
    [SerializeField] public float minSpeed;
    [SerializeField] public float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded;

    [SerializeField] private Animator animator;

    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isGrounded)
        {
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Jump", true);
        }

        Movement();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && Input.GetKeyDown("w"))
        {
            Jump();
        }
    }

    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        if (x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }

        if (x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Jump()
    {

        rb.AddForce(transform.up * jumpSpeed);
    }
}
