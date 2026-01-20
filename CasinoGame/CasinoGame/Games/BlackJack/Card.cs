using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame.Games.BlackJack
{
    public enum Suits
    {
        Diamonds = 1,
        Hearts = 2,
        Clubs = 3,
        Spades = 4
    }

    public enum Ranks
    {
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public struct Card
    {
        readonly Suits Suit;
        readonly Ranks Rank;

        public Card(Suits suit, Ranks rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
