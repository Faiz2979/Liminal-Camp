using UnityEngine;
using UnityEngine.InputSystem;
using Service.PlayerController;
using Yarn.Unity;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;

    private PlayerControllerService _service;
    private PlayerInputSystem _input;

    private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;

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

    [YarnCommand("SetAnimatorState")]
    public void SetAnimatorState(string param, bool state)
    {
        Debug.Log("Set " + param + " to " + state);
        _animator.SetBool(param, state);
    }

    private void Update()
    {
        // Jangan bisa bergerak saat Focus (cutscene / dialog)
        if (_animator.GetBool("Focus"))
            return;

        Vector2 moveInput = _input.Player.Move.ReadValue<Vector2>();

        // WALK ANIMATION
        bool isWalking = Mathf.Abs(moveInput.x) > 0.01f;
        _animator.SetBool("Walk", isWalking);

        // FLIP PLAYER
        if (isWalking)
        {
            Flip(moveInput.x);
        }

        // MOVE
        _service.Move(moveInput.x);
    }

    private void Flip(float direction)
    {
        Vector3 scale = transform.localScale;

        if (direction > 0)
            scale.x = Mathf.Abs(scale.x);   // Hadap kanan
        else if (direction < 0)
            scale.x = -Mathf.Abs(scale.x);  // Hadap kiri

        transform.localScale = scale;
    }

}
