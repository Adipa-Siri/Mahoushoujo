using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour

{
    //movement
    public Rigidbody2D rb;
    public float speed = 5f;
    public float horizontal;
    public float jumpForce = 10f;
    //ground check
    [SerializeField] private Transform groundCheck;
    public bool isGrounded;
    //collider
    public Collider2D collision;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump")&& (isGrounded==true))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

    }
    public void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);


    }

  
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}