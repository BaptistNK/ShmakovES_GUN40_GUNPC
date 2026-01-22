using CasinoGame.Games.Dice;

namespace CasinoGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new DiceGame(sum:20,min:1,max:6);
            Console.WriteLine("Start:");
            game.PrintDice();

            Console.WriteLine();
            game.PrintDice();
            
        }
    }
}
