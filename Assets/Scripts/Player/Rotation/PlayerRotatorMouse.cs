
using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;

namespace Assets.Scripts.Player.Rotation
{
    public class PlayerRotatorMouse : IPlayerInputRotator
    {
        Plane _groundPlane;

        public PlayerRotatorMouse() =>
            _groundPlane = new Plane(Vector3.up, Vector3.zero);

        public void Rotate(Transform playerTransform)
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (_groundPlane.Raycast(cameraRay, out var rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);

                playerTransform.LookAt(new Vector3(pointToLook.x, playerTransform.position.y, pointToLook.z));
                playerTransform.Rotate(new Vector3(playerTransform.rotation.x, playerTransform.rotation.y + 90, playerTransform.rotation.z));
            }
        }
    }
}