using UnityEngine;

public class BugBehav : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float movementMultip;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float jumpTimer;
    [SerializeField] private float direction;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(11, 11);

        if (transform.position.x < 0)
        {
            direction = 1;
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else if (transform.position.x > 0)
        {
            direction = -1;
            transform.localRotation = Quaternion.Euler(0, -180, 0);
        }
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float moveBy = direction * speed;
        moveBy = moveBy * movementMultip;

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }

        if(collision.collider.tag == "Ground")
        {
            movementMultip = 1;
        }     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerStats.playerPoints += 3;

            Destroy(gameObject);
        }

        if(collision.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
