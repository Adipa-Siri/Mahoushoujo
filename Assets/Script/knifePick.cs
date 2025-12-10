using UnityEngine;

public class knifePick : MonoBehaviour
{
    public GameObject knife;
    public Collider2D pickup;
    public knifeManage knives;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("knife"))
        {
            knives.knife += 1;
            Destroy(other.gameObject);
        }
    }
}
