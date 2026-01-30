using UnityEngine;

namespace Service.PlayerController
{
    public class PlayerControllerService
    {
        private readonly Rigidbody2D _rb;
        private readonly float _moveSpeed;

        public PlayerControllerService(Rigidbody2D rb, float moveSpeed)
        {
            _rb = rb;
            _moveSpeed = moveSpeed;
        }

        public void Move(float horizontal)
        {
            _rb.linearVelocity = new Vector2(horizontal * _moveSpeed, _rb.linearVelocity.y);
        }
    }
}
