using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering.Analytics;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    private Vector2 screenBounds;
    public spawnerK kCount;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

