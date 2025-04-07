using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;

namespace Assets.Scripts.Player.Rotation
{
    public class PlayerRotatorMouse : IPlayerInputRotator
    {
        private Plane _groundPlane = new Plane(Vector3.up, Vector3.zero);

        public void Rotate(Transform playerTransform)
        {
            // Sistema antiguo con Input.mousePosition
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (_groundPlane.Raycast(cameraRay, out float rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                ApplyRotation(playerTransform, pointToLook);
            }
        }

        private void ApplyRotation(Transform targetTransform, Vector3 lookPoint)
        {
            Vector3 fixedPosition = new Vector3(
                lookPoint.x, 
                targetTransform.position.y, 
                lookPoint.z
            );

            targetTransform.LookAt(fixedPosition);
            targetTransform.Rotate(0, 90, 0);
        }
    }
}