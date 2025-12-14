using UnityEngine;

public class intercollide : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public GameObject coll;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coll.SetActive(false);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            coll.SetActive(true);
        }
    }
}
