using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame.Game
{
    abstract class CasinoGameBase
    {
        public delegate bool OnWin();
        public delegate bool OnLoose();
        public delegate bool OnDraw();
        public abstract void PlayGame();
        

    }
}
