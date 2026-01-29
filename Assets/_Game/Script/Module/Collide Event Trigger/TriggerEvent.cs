using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    private IInteractable currentInteractable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        currentInteractable = GetComponent<IInteractable>();

        if (currentInteractable != null)
        {
            PlayerInteractor.Instance.SetInteractable(currentInteractable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        PlayerInteractor.Instance.ClearInteractable();
        currentInteractable = null;
    }
}
