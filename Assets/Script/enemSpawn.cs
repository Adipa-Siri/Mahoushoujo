using System.Collections;
using UnityEngine;

public class enemSpawn : MonoBehaviour
{
    private int num;
    public GameObject enemy;
    public Transform spawnPoint;
    private float cooldown = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        while (true)
        {
            
                Instantiate(enemy, new Vector2(spawnPoint.position.x * Random.Range(1, 3), spawnPoint.position.y), Quaternion.identity);
            
            yield return new WaitForSeconds(cooldown);
        }
    }
}
