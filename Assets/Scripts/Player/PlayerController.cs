using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] bool isPlayerTestDummy;

        IPlayerMediator _mediator;

        public void Configure(IPlayerMediator mediator) =>
            _mediator = mediator;

        private void Update()
        {
            if(isPlayerTestDummy) return;

            _mediator.DoAttack();
        }

        public void DestroyPlayer() =>
            Destroy(gameObject);
    }
}