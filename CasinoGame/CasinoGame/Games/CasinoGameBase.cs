using System;
namespace CasinoGame.Games
{
    public abstract class CasinoGameBase
    {
        public event Action<int> OnWin;
        public event Action<int> OnLose;
        public event Action<int> OnDraw;

        protected CasinoGameBase() { }

        protected abstract void FactoryMethod();
        public abstract void PlayGame(int bet);

        protected void OnWinInvoke(int amount)
        {
            OnWin?.Invoke(amount);
        }

        protected void OnLoseInvoke(int amount)
        {
            OnLose?.Invoke(amount);
        }

        protected void OnDrawInvoke(int amount)
        {
            OnDraw?.Invoke(amount);
        }
    }
}
