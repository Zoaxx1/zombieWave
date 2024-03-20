using Assets.Scripts.Player;

namespace Assets.Scripts.Interfaces.IPlayer
{
    public interface IPlayerMediator
    {
        public void LifeZero();

        public void DoAttack();

        public void DoShootFireOne();

        public void DoShootFireTwo();
    }
}
