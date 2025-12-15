using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class spawnerK : MonoBehaviour
{
    private int num;
    public knifeManage knifeCount;
    public GameObject knife;
    public Transform spawnPoint;
    public Transform player;
    private float cooldown = 5f;

    private void Start()
    {
        StartCoroutine(spawntimer());
    }

    private void Update()
    {
            spawnKnife();
           
    }
    void spawnKnife()
    {


        if (knifeCount.knife < 1 && Input.GetKeyDown(KeyCode.Mouse1))
        {
            num = Random.Range(0, 15);
            
            if (num == 2 || num == 4 || num==10 )
            {
                Instantiate(knife,new Vector2(player.position.x, player.position.y) , Quaternion.identity);
                
            }
        }
    }

    IEnumerator spawntimer()
    {
        while (true)
        {

            Instantiate(knife, new Vector2(spawnPoint.position.x * Random.Range(1, 3), spawnPoint.position.y), Quaternion.identity);


            yield return new WaitForSeconds(cooldown);//when cooldown reached spawn the knife near by player
        }
    }
}
