using UnityEngine;
using UnityEngine.UI;

public class knifeManage : MonoBehaviour
{
    public int knife;
    public Text knifecount;
    // Update is called once per frame
    void Update()
    {
        knifecount.text = ": " + knife.ToString();
    }
}
