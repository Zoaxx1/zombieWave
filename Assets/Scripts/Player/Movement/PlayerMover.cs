using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player.Movement
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] float speed = 400;
        Vector3 _input;

        private void Update() =>
            _input = GetInput();

        private void FixedUpdate() =>
            Move();

        Vector3 GetInput()
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");
            return new Vector3(inputX, 0, inputY);
        }

        void Move() =>
            rb.velocity = _input * speed * Time.deltaTime;
    }
}