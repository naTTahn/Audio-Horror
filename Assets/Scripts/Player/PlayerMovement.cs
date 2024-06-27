using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private const float DefaultSpeed = 5f;
        private const float SprintSpeed = 10f;
        private const float Gravity = -20f;
        private const float TerminalVelocity = -30f;
        private const float JumpVelocity = 1.4f;

        private CharacterController _controller;
        private Vector3 _playerVelocity;
        public bool isGrounded;
        public float speed = DefaultSpeed;
        [FormerlySerializedAs("Sprinting")] public bool sprinting;

        void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            isGrounded = _controller.isGrounded;
        }

        public void ProcessMove(Vector2 input)
        {
            Vector3 moveDirection = new Vector3(input.x, 0, input.y);
            MovePlayer(moveDirection);
            ApplyGravity();
        }

        private void MovePlayer(Vector3 direction)
        {
            _controller.Move(transform.TransformDirection(direction) * (speed * Time.deltaTime));
        }

        private void ApplyGravity()
        {
            if (!isGrounded)
            {
                _playerVelocity.y += Gravity * Time.deltaTime; // apply gravity if the player is not grounded
                if (_playerVelocity.y < TerminalVelocity)
                {
                    _playerVelocity.y = TerminalVelocity; //make the player not fall too fast
                }
            }

            _controller.Move(_playerVelocity * Time.deltaTime);
        }

        public void StartSprint()
        {
            if (isGrounded)
                speed = SprintSpeed;
        }

        public void StopSprint()
        {
            speed = DefaultSpeed;
        }

        public void Jump()
        {
            if (isGrounded)
            {
                _playerVelocity.y = Mathf.Sqrt(JumpVelocity * -3.0f * Gravity);
            }
        }
    }
}