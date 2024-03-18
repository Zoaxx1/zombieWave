using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] PlayerInputs input;

        [SerializeField] bool isPlayerTestDummy;

        IPlayerMediator _mediator;

        public void Configure(IPlayerMediator mediator) =>
            _mediator = mediator;

        void Start(){
            if (isPlayerTestDummy) return;

            _mediator.UseInput(input);
        }

        private void FixedUpdate()
        {
            if (isPlayerTestDummy) return;

            _mediator.DoMove();
        }

        private void Update()
        {
            if(isPlayerTestDummy) return;

            _mediator.DoRotate();

            _mediator.DoAttack();
        }

        public void DestroyPlayer() =>
            Destroy(gameObject);
    }
}