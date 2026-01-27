namespace CasinoGame.Games.Dice
{
    public class Dice
    {
        private static readonly Random _random = new Random();
        private readonly int _min;
        private readonly int _max;

        public int Number => _random.Next(_min, _max + 1);

        public Dice(int min, int max)
        {
            if (min < 1)
                throw new WrongDiceNumberException(min, 1, int.MaxValue);

            if (max > int.MaxValue)
                throw new WrongDiceNumberException(max, 1, int.MaxValue);

            if (min > max)
                throw new ArgumentException("Min cannot be greater than max");

            _min = min;
            _max = max;
        }
    }
}
