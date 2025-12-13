using Unity.VisualScripting;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float maxHp = 10.0f;
    public float currentHp;

    void Start()
    {
        currentHp = maxHp;
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
