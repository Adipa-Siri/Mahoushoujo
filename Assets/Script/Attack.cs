using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask EnemyLayers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            attack();
        }
    }

    public void attack()
    {
       
            animator.SetTrigger("isAttacking");

        Physics2D.OverlapCircleAll(attackPoint.position,attackRange,EnemyLayers);
        
    }
}