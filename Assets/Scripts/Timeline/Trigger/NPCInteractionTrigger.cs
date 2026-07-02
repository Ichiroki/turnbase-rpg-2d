using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public GameObject interactIcon;

    private bool canInteract;

    public System.Action onInteract;

    void Start()
    {
        interactIcon.SetActive(false);
    }

    void Update()
    {
        if (!canInteract) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            onInteract?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        canInteract = true;
        interactIcon.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        canInteract = false;
        interactIcon.SetActive(false);
    }
}
