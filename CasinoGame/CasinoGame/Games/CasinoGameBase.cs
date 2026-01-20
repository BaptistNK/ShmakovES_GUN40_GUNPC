using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame.Games
{
    public abstract class CasinoGameBase
    {
        public Action OnWin;
        public Action OnLoose;
        public Action OnDraw;
        public abstract void PlayGame();

        public CasinoGameBase()
        {
            FactoryMethod();
        }
        protected void OnWinInvoke()
        {
            OnWin?.Invoke();
        }

        protected void OnLooseInvoke()
        { 
            OnLoose?.Invoke(); 
        }

        protected void OnDrawInvoke()
        {
            OnDraw?.Invoke();
        }

        protected abstract void FactoryMethod();
    }
}
