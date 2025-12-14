using UnityEngine;

public class Despawn : MonoBehaviour
{
    private Vector3 screenBounds;
    public GameObject enemy;
    

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > screenBounds.x * 2 || transform.position.x < screenBounds.x * -2)
        {
            Destroy(gameObject);

        }
        
    }
}
