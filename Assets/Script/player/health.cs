using Unity.VisualScripting;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float maxHp = 10.0f;
    public float currentHp;
    public Transform respawn;
    public GameObject player;
    
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
        player.transform.position = respawn.position;
        currentHp = maxHp;
       
    }
}
