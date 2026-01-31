using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    private IInteractable currentInteractable;

    private void Awake()
    {
        currentInteractable = GetComponent<IInteractable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (currentInteractable != null && PlayerInteractor.Instance != null)
        {
            PlayerInteractor.Instance.SetInteractable(currentInteractable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (UIPopup.Instance != null && UIPopup.Instance.gameObject.activeInHierarchy)
        {
            UIPopup.Instance.Hide();
        }

        if (PlayerInteractor.Instance != null)
        {
            PlayerInteractor.Instance.ClearInteractable();
        }
    }
}
