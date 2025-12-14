using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;

public class Hun : MonoBehaviour
{
    
    private Rigidbody2D rb;
    [SerializeField] private int atk = 10;
    private float speed = 2.5f;
    public float targetRange = 0.2f;
    public Transform target,atkpoint;
    public float atkRange = 0.5f;
    public bool flip = true;
    public LayerMask PlayerLayers;
    [SerializeField] Animator animator;
    public GameObject iris;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(killspawn());
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
        attack();
        
    }

    void FixedUpdate()
    {
        Detection();
    }

    public void attack()
    {

        Collider2D[] HitPlayer = Physics2D.OverlapCircleAll(atkpoint.position, atkRange, PlayerLayers);

        foreach (Collider2D player in HitPlayer)
        {
                animator.SetTrigger("atk");
                player.GetComponent<health>().DamTaken(atk);
                
        }


        }
    
    private void die()
    {
        Destroy(gameObject);
       
        Instantiate (iris, transform.position, Quaternion.identity);
    }

    public void Detection()
    {

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

    IEnumerator killspawn()
    {
        yield return new WaitForSeconds(5f);
        die();
    }
}
