using System.Collections;
using UnityEngine;

public class enemSpawn : MonoBehaviour
{
    private int num;
    public GameObject enemy;
    public Transform spawnPoint;
    public Transform player;
    [SerializeField] private float cooldown = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        while (true)
        {
            
                Instantiate(enemy, new Vector2(spawnPoint.position.x * Random.Range(1, 3), player.position.y), Quaternion.identity);
            
            yield return new WaitForSeconds(cooldown);//when cooldown reached spawn the enemy near by player
        }
    }
}
