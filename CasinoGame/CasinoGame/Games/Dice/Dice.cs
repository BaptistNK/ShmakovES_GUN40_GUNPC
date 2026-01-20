namespace CasinoGame.Games.Dice
{
    class Dice
    {
        private readonly Random _random;
        private readonly int Min;
        private readonly int Max;
        public int Number =>_random.Next(Min, Max);

        Dice(int min, int max)
        {
            if(min < 1 || min > int.MaxValue)
            {
                throw new WrongDiceNumberException(min > max ? min : max, min: 1, int.MaxValue);
            }
        }
    }
}
