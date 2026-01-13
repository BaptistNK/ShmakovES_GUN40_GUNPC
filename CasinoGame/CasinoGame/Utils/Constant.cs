using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame.Constant
{
    public static class Constant
    {
        public enum SuitName
        {
            Hearts, //черви
            Diamonds, //бубны
            Clubs, //трефы
            Spades //пики
        }
        public enum SizeCard
        {
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Ace
        }
        public readonly struct Card
        {
            public string Suit { get; }
            public string Value { get; }

            public Card(string suit, string value)
            {
                Suit = suit;
                Value = value;
            }
        }

        public readonly struct Dice
        {
            private readonly int _number;
            private readonly Random _random;
            private int Min { get; }
            private int Max { get; }

            public int Number { get { return _random.Next(Min, Max); } }
            Dice(int min, int max)
            {
                Min = min;
                Max = max;
            }
        }
    }
}
