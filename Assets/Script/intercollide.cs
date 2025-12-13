using UnityEngine;

public class intercollide : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public GameObject collision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collision.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            Debug.Log("Collide");
            collision.SetActive(true);
        }
    }
}
