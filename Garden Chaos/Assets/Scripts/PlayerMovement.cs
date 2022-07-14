using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -19.81f;
    public float jumpHeight = 10f;
    public Transform groundCheck;
    float groundDiastance = 0.3f;
    public LayerMask groundMask;
    Vector3 velocity;
    public bool isGrounded;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDiastance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey("c"))
        {
            controller.height = 1.5f;
        }
        else { 
        controller.height = 3f;
        }
    }
}
