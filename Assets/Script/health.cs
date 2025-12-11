using Unity.VisualScripting;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float maxHp = 10.0f;
    float currentHp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamTaken(int dam)
    {
        currentHp -= dam;
        if (currentHp < 1)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
    }
}
