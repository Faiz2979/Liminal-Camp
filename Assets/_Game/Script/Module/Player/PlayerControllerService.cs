using UnityEngine;

namespace Service.PlayerController
{
    public class PlayerControllerService
    {
        private readonly Rigidbody2D _rb;
        private readonly float _moveSpeed;
        private readonly float _jumpForce;

        public PlayerControllerService(Rigidbody2D rb, float moveSpeed, float jumpForce)
        {
            _rb = rb;
            _moveSpeed = moveSpeed;
            _jumpForce = jumpForce;
        }

        public void Move(float horizontal)
        {
            _rb.linearVelocity = new Vector2(horizontal * _moveSpeed, _rb.linearVelocity.y);
        }

        public void Jump(bool isGrounded)
        {
            if (!isGrounded) return;

            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
        }
    }
}
