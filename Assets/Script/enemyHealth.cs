using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private float MaxHp = 15.0f;
    [SerializeField] float currentHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = MaxHp;
    }

    public void DamageTaken(int dam)
    {
        currentHP -= dam;

        if (currentHP < 1)
        {
            die();
        }

    }

    public void die()
    {
        animator.SetBool("isDead", true);

        Destroy(gameObject, 0.5f);
        
    }
}
