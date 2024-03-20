using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player.Rotation
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] PlayerInput playerInput;

        private void Update()
        {
            Rotate();
        }

        public void Rotate()
        {
            var position = playerInput.actions["Rotation"].ReadValue<Vector2>();

            var mousePosition = Camera.main.ScreenToWorldPoint(position);

            Debug.Log(mousePosition);

            transform.LookAt(new Vector3(mousePosition.x, transform.position.y, mousePosition.y));
            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z));
        }
    }
}