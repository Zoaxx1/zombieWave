using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player.Movement
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] float speed = 400;
        [SerializeField] PlayerInput playerInput;
        Vector3 _input;

        private void Update() =>
            _input = GetInput();

        private void FixedUpdate() =>
            Move();

        Vector3 GetInput()
        {
            Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
            return new Vector3(input.x, 0, input.y);
        }

        void Move() =>
            rb.velocity = _input * speed * Time.deltaTime;
    }
}