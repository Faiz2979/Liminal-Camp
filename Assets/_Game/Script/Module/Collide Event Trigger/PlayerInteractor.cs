using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    public static PlayerInteractor Instance { get; private set; }

    private PlayerInputSystem _input;
    private IInteractable _current;

    [SerializeField] private GameObject _canInteractPopUp;
    private void Awake()
    {
        Instance = this;
        _input = new PlayerInputSystem();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        _input.Player.Interact.performed -= OnInteract;
        _input.Disable();
    }

    private void OnInteract(InputAction.CallbackContext ctx)
    {
        _current?.Interact();
    }

    public void SetInteractable(IInteractable interactable)
    {
        Debug.Log("SET INTERACTABLE");
        _current = interactable;
        _canInteractPopUp.SetActive(true);
    }

    public void ClearInteractable()
    {
        Debug.Log("CLEAR INTERACTABLE");
        _current = null;
        _canInteractPopUp.SetActive(false);
    }
}
