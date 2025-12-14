using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class spawnerK : MonoBehaviour
{
    private int num;
    public knifeManage knifeCount;
    public GameObject knife;
    public Transform spawnPoint;

    private void Update()
    {
       spawnKnife();
    }
    void spawnKnife()
    {
        if (knifeCount.knife < 1 && Input.GetKeyDown(KeyCode.Mouse1))
        {
            num = Random.Range(0, 11);
            Debug.Log(num);
            if (num == 10 || num == 6)
            {
                Debug.Log("Spawn Knife");
                Instantiate(knife,new Vector2(spawnPoint.position.x*Random.Range(1,4), spawnPoint.position.y) , Quaternion.identity);
            }
        }
    }
}
