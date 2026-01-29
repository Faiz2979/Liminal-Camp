using UnityEngine;
using UnityEngine.InputSystem;
using Service.PlayerController;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 12f;

    [Header("Ground Check")]
    [SerializeField] private Transform[] groundCheck = new Transform[2];
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private PlayerControllerService _service;
    private PlayerInputSystem _input;

    private Rigidbody2D _rb;
    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _service = new PlayerControllerService(_rb, moveSpeed, jumpForce);

        _input = new PlayerInputSystem();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Jump.performed += ctx => _service.Jump(_isGrounded);
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        CheckGround();

        Vector2 moveInput = _input.Player.Move.ReadValue<Vector2>();
        _service.Move(moveInput.x);
    }


    private void CheckGround()
    {
        foreach (var check in groundCheck)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(check.position, Vector2.down, groundRadius, groundLayer);
            if (hits.Length > 0)
            {
                _isGrounded = true;
                return;
            }
        }
        _isGrounded = false;
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
