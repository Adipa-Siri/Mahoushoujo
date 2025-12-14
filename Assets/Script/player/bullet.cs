using UnityEngine;


public class bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public Collider2D bulletCollider;
    int damage = 2;
    Vector2 screenBounds;
    Vector2 moveDirection;
    public float lifeTime = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    private void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        rb.linearVelocity = moveDirection * speed;
    }

    private void Update()
    {

        if (transform.position.x > screenBounds.x * 2 || transform.position.x < screenBounds.x * -2 || transform.position.y > screenBounds.y * 2 || transform.position.y < screenBounds.y * -2)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, lifeTime);
    }
    
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir.normalized;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {    
        if (collision.gameObject.CompareTag("enemy"))
        {
            enemyHealth enemyHealth = collision.gameObject.GetComponent<enemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.DamageTaken(damage);
            }
            Destroy(gameObject);
        }
        
    }

}
