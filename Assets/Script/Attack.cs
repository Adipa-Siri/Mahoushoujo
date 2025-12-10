using UnityEngine;
using UnityEngine.Rendering;

public class Attack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask EnemyLayers;
    public knifeManage knives;
    float Mdamage = 3.0f;
    float Rdamage = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attackMelee();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            attackLong();
            knives.knife -= 1;
            //knives will not go below 0
            if( knives.knife < 0)
            {
                knives.knife = 0;
            }

        }

        
    }

    public void attackMelee()
    {
        if(knives.knife > 0) {
            animator.SetTrigger("isAttacking");

            //detect range enemy
            


                Collider2D[] HitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLayers);

                foreach (Collider2D Enemy in HitEnemy)
                {

                    Debug.Log("You hit!");

                }
            

        }
        else
        {


        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

    public void attackLong()
    {
        if (knives.knife > 0)
        {
            animator.SetTrigger("isAttacking");

        }
        else
        {


        }

    }
}