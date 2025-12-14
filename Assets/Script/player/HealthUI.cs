using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text healthText;
    public health playerHealth;

  

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerHealth.currentHp.ToString() + " / 10" ;
    }
}
