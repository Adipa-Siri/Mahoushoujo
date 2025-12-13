using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class spawnerK : MonoBehaviour
{
    public GameObject knife;
    [SerializeField]
    private float spawnRate = 3f;//1knife every 3 seconds
   
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            StartCoroutine(spawn(spawnRate,knife));
       

    }

    void Update()
    {
     
    }


    // Update is called once per frame
    private IEnumerator spawn(float interval,GameObject knives)
    {
        yield return new WaitForSeconds(interval);

        GameObject newKnife = Instantiate(knives, new Vector2(Random.Range(0,10),-1), Quaternion.identity);
        
        StartCoroutine(spawn(interval,knives));
    }
}
