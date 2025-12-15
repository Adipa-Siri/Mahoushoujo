using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private float MaxHp = 15.0f;
    [SerializeField] float currentHP;
    public GameObject Hunter;
    private AudioSource audioSource;
    public AudioClip hurt;
    int gambling;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentHP = MaxHp;
    }

    public void DamageTaken(int dam)
    {
       
        currentHP -= dam;//take damage
        if (currentHP < 1)
        {
            audioSource.PlayOneShot(hurt, 0.5f);
            die();
        }

    }

    public void die()
    {
        animator.SetBool("isDead", true);

        Destroy(gameObject, 0.5f);

        gambling = Random.Range(0,11);

        if(gambling % 2 == 0)

        {
            Instantiate (Hunter, transform.position, Quaternion.identity);//spawn Hun at the enemy death position
        }

        
        


    }
}
