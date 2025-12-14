using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Attack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask EnemyLayers;
    public knifeManage knives;
    int Mdamage = 3;
   
    //range attack
    public GameObject bulletPrefab;
    public GameObject knife;
    Vector2 aim;
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0)
        {
            aim = Vector2.left;
        }
        else if (horizontal > 0)
        {
            aim = Vector2.right;
        }

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

                    Enemy.GetComponent<enemyHealth>().DamageTaken(Mdamage);

            }
            

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

           
           GameObject Bull =  Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
              bullet bullScript = Bull.GetComponent<bullet>();
                bullScript.SetMoveDirection(aim);




        }

    }
}