using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private float MaxHp = 10.0f;
    float currentHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
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

        this.enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}
