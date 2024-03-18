using Assets.Scripts.Player;

namespace Assets.Scripts.Interfaces.IPlayer
{
    public interface IPlayerMediator
    {
        public void UseInput(PlayerInputs input);

        public void LifeZero();

        public void DoMove();

        public void DoRotate();

        public void DoAttack();

        public void DoShootFireOne();

        public void DoShootFireTwo();
    }
}
