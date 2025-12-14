using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public Transform atkPoint;
    public float atkRange = 0.5f;
    [SerializeField] Animator animator;
    public LayerMask PlayerLayers;
    int damage = 1;
    float atkCooldown = 2f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(atkCooldown > 0)
        {
            atkCooldown -= Time.deltaTime;
        }
        atk();
    
    }

   public void atk()
    {
        
        Collider2D[] HitPlayer = Physics2D.OverlapCircleAll(atkPoint.position, atkRange, PlayerLayers);

        foreach (Collider2D player in HitPlayer)
        {
            if(atkCooldown<= 0) {
            atkCooldown = 2f;
                animator.SetTrigger("isAttack");
                player.GetComponent<health>().DamTaken(damage);
            }
            

        }
    }

    
}
