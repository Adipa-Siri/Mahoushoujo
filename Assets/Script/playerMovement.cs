using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour

{
    //movement
    public Rigidbody2D rb;
    public float speed = 5f;
    public float horizontal;
    public float vertical;
    public float jumpForce = 5f;
    //ground check
    [SerializeField] private Transform groundCheck;
    public bool isGrounded;
    //collider
    public Collider2D collision;
    //Animation
    [SerializeField] private Animator animator;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //walking
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("speed", Mathf.Abs(horizontal));//walking check
        animator.SetFloat("inputX", horizontal);//fliping
            Jump();
        

    }
    public void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);
        

    }



    
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded == true))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }
    }
    
  
  
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
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