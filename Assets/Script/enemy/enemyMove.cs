using UnityEngine;
using UnityEngine.EventSystems;

public class enemyMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float speed = 2f;
    public float targetRange = 0.2f;
    public Transform target;
    public bool flip = true;
    public LayerMask PlayerLayers;
    [SerializeField] Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    { 


        if (target)
        {

            //flip enemy to face player
            Vector2 direction = (target.position - transform.position).normalized;
            if (direction.x < 0 && !flip)
            {
                Flip();
            }
            if (direction.x > 0 && flip)
            {
                Flip();
            }
        }

    }

    void FixedUpdate()
    {
        Detection();
    }


    public void Detection() {

        Collider2D[] Detect = Physics2D.OverlapCircleAll(gameObject.transform.position, targetRange, PlayerLayers);


        foreach (Collider2D player in Detect)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);
            animator.SetFloat("speed", Mathf.Abs(rb.linearVelocity.x));
        }


    }
    
    void Flip()
    {
        Vector3 current = gameObject.transform.localScale;
        current.x *= -1;
        gameObject.transform.localScale = current;
        flip = !flip;
    }
}
