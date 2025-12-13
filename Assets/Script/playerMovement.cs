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
    public bool flip = true;
    

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
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        if (horizontal < 0 && !flip) {
        Flip();
        
        }
        if (horizontal > 0 && flip)
        {
            Flip();

        }

    }



    
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded == true))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }
    }
    
    public void Flip()
    {
        Vector3 current = gameObject.transform.localScale;
        current.x *= -1;
        gameObject.transform.localScale = current;
        flip = !flip;
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