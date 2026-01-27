namespace CasinoGame.Games.Dice
{
    public class DiceGame : CasinoGameBase
    {
        private readonly int _numberOfDice;
        private readonly int _minValue;
        private readonly int _maxValue;
        private List<Dice> _diceCollection;

        public DiceGame(int numberOfDice, int minValue, int maxValue)
        {
            if (numberOfDice <= 0)
                throw new ArgumentException("Number of dice must be positive", nameof(numberOfDice));

            if (minValue >= maxValue)
                throw new ArgumentException("Min value must be less than max value");

            _numberOfDice = numberOfDice;
            _minValue = minValue;
            _maxValue = maxValue;
            _diceCollection = new List<Dice>();
        }

        protected override void FactoryMethod()
        {
            for (int i = 0; i < _numberOfDice; i++)
            {
                _diceCollection.Add(new Dice(_minValue, _maxValue));
            }
        }

        public override void PlayGame(int bet)
        {
            FactoryMethod();
            var playerResults = RollDice();
            var computerResults = RollDice();

            Console.WriteLine("Your dice results:");
            DisplayDiceResults(playerResults);

            Console.WriteLine("\nComputer's dice results:");
            DisplayDiceResults(computerResults);

            int playerTotal = playerResults.Sum();
            int computerTotal = computerResults.Sum();

            Console.WriteLine($"\nYour total: {playerTotal}");
            Console.WriteLine($"Computer's total: {computerTotal}");

            if (playerTotal > computerTotal)
            {
                Console.WriteLine("\nYou win!");
                OnWinInvoke(bet);
            }
            else if (computerTotal > playerTotal)
            {
                Console.WriteLine("\nComputer wins!");
                OnLoseInvoke(bet);
            }
            else
            {
                Console.WriteLine("\nIt's a draw!");
                OnDrawInvoke(bet);
            }
        }

        private List<int> RollDice()
        {
            var results = new List<int>();
            foreach (var dice in _diceCollection)
            {
                results.Add(dice.Number);
            }
            return results;
        }

        private void DisplayDiceResults(List<int> results)
        {
            foreach (var result in results)
            {
                Console.Write($"{result} ");
            }
            Console.WriteLine();
        }
    }
}
