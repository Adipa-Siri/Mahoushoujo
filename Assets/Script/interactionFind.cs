using UnityEngine;


public class interactionFind : MonoBehaviour
{
    private Interactable inter = null;
    public GameObject interIcon;
   
    void Start()
    {
        interIcon.SetActive(false);
    }
    public void OnInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inter?.Interact();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interactable interactable) && interactable.CanInteract())
        {
            inter = interactable;
            interIcon.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interactable interactable) && interactable == inter)
        {
            inter = null;
            interIcon.SetActive(false);
        }
    }
}
