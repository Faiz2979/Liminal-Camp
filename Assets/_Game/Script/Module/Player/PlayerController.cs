using UnityEngine;
using UnityEngine.InputSystem;
using Service.PlayerController;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;

    [Header("Ground Check")]
    [SerializeField] private Transform[] groundCheck = new Transform[2];
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private PlayerControllerService _service;
    private PlayerInputSystem _input;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _service = new PlayerControllerService(_rb, moveSpeed);

        _input = new PlayerInputSystem();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        Vector2 moveInput = _input.Player.Move.ReadValue<Vector2>();
        _service.Move(moveInput.x);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (var check in groundCheck)
        {
            Gizmos.DrawRay(check.position, Vector2.down * groundRadius);
        }
    }
}
