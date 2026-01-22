namespace CasinoGame.Games.Dice
{
    public class DiceGame : CasinoGameBase
    {
        private readonly List<Dice> _diceCollection = new List<Dice>();
        private readonly DiceFactory _factory;
        public int Sum => _diceCollection.Sum(d => d.Number);

        public DiceGame(int sum, int min, int max)
        {
            if (sum <= 0)
            {
                 throw new ArgumentOutOfRangeException(nameof(sum), "sum < 0!");
            }
            if (min >= max)
            { 
                throw new ArgumentException("Min < Max!");
            }

            _factory = new StandardDiceFactory();

            while (Sum < sum)
            {
                var dice = _factory.CreateDice(min, max);
                _diceCollection.Add(dice);
            }
        }
        protected virtual Dice CreateDice(int min, int max)
        {
            return _factory.CreateDice(min,max);
        }

        public void PrintDice()
        {
            Console.WriteLine("Roll dice:");
            for (int i = 0; i < _diceCollection.Count; i++) 
            {
                Console.WriteLine($"Dice {i+1}: {_diceCollection[i].Number}");
            }
        }
        public override void PlayGame()
        {
            throw new NotImplementedException();
        }

        protected override void FactoryMethod()
        {

        }
    }
}
