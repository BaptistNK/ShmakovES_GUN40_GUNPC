namespace CasinoGame.Games.Dice
{
    public class Dice
    {
        private readonly Random _random = new Random();
        private readonly int min;
        private readonly int max;
        public int Number => _random.Next(min, max + 1);

        public Dice(int min, int max)
        {
            if(min < 1 || min > int.MaxValue)
            {
                throw new WrongDiceNumberException(min > max ? min : max, min: 1, int.MaxValue);
            }
        }
    }
}
