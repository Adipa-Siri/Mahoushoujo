using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour

{
    public Rigidbody2D rb;
    public float speed = 5f;
     float horizontalMovement;
    public float jumpForce = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * speed,rb.linearVelocity.y);
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement= context.ReadValue<Vector2>().x;
        
    }
    public void Jump(InputAction.CallbackContext context)
    { 
        if (context.performed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }


    }
}
