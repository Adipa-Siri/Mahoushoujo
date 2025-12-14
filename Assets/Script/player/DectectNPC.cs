using UnityEngine;
using UnityEngine.Rendering;

public class DectectNPC : MonoBehaviour
{

    private Interaction interactR = null;
    public GameObject interIcon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interIcon.SetActive(false);
    }

    
    private void Update() { 
    {
            if (Input.GetKeyDown(KeyCode.E)&& interactR !=null)
            {
               
                interactR?.Interact();
            }
        }
}
void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Interaction>(out Interaction interact) && interact.CanInteract())
        {
            interactR = interact;
            interIcon.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Interaction>(out Interaction interact) && interact==interactR)
        {
            interactR = null;
            interIcon.SetActive(false);
        }
    }
}
