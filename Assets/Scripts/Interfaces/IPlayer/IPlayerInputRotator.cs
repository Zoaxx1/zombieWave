using UnityEngine;

namespace Assets.Scripts.Interfaces.IPlayer
{
    public interface IPlayerInputRotator
    {
        public void Rotate(Transform playerTransform);
    }
}