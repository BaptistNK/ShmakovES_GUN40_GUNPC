namespace CasinoGame.Games
{
    public class Casino : IGame
    {
        private int _balance;
        public void StartGame()
        {
            Console.WriteLine($"Welcome to the casino! /n Your balance: {_balance}");

            while (_balance>0)
            {
                Console.WriteLine();
            }
        }
    }
}
