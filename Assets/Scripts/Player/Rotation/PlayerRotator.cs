using UnityEngine;

namespace Assets.Scripts.Player.Rotation
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private float groundHeight = 0f;  // Altura del suelo en Y
        private Plane _groundPlane;

        private void Start()
        {
            _groundPlane = new Plane(Vector3.up, new Vector3(0, groundHeight, 0));
        }

        private void Update()
        {
            Rotate();
        }

        public void Rotate()
        {
            // Usamos Input.mousePosition directamente
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (_groundPlane.Raycast(cameraRay, out float rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                ApplyRotation(pointToLook);
            }
        }

        private void ApplyRotation(Vector3 targetPosition)
        {
            // Mantenemos la altura original del jugador
            Vector3 fixedPosition = new Vector3(
                targetPosition.x, 
                transform.position.y, 
                targetPosition.z
            );

            transform.LookAt(fixedPosition);
            // Ajuste de rotación si es necesario
            transform.Rotate(0, 90, 0);  // Rotación fija en Y
        }
    }
}