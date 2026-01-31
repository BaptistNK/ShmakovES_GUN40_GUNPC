using CasinoGame.Data;
using CasinoGame.Games;
using CasinoApp;
using CasinoGame.Games.Dice;
using CasinoGame.Core;
using CasinoApp.Games.Blackjack;

namespace CasinoApp.Core
{
    public class Casino : IGame
    {
        private const int MAX_BANK_VALUE = 100000;
        private const string PROFILES_DIRECTORY = "Profiles";

        private readonly ISaveLoadService<string> _saveLoadService;
        private readonly Dictionary<int, CasinoGameBase> _availableGames;
        private PlayerProfile _playerProfile;

        public Casino()
        {
            _saveLoadService = new FileSystemSaveLoadService(PROFILES_DIRECTORY);
            _availableGames = InitializeGames();
        }

        private Dictionary<int, CasinoGameBase> InitializeGames()
        {
            return new Dictionary<int, CasinoGameBase>
            {
                { 1, new BlackjackGame(36) }, // 36 cards for Blackjack
                { 2, new DiceGame(2, 1, 6) }  // 2 dice with values 1-6
            };
        }

        public void StartGame()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("       Welcome to the Casino!       ");
            Console.WriteLine("====================================\n");

            LoadOrCreateProfile();

            while (true)
            {
                if (_playerProfile.Bank <= 0)
                {
                    Console.WriteLine("\nNo money? Kicked!");
                    break;
                }

                Console.WriteLine($"\nYour bank: ${_playerProfile.Bank}");
                Console.WriteLine("\nChoose a game:");
                Console.WriteLine("1. Blackjack");
                Console.WriteLine("2. Dice Game");
                Console.WriteLine("3. Exit");
                Console.Write("\nYour choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (choice == 3)
                {
                    Console.WriteLine($"\nGoodbye, {_playerProfile.Name}!");
                    SaveProfile();
                    break;
                }

                if (!_availableGames.ContainsKey(choice))
                {
                    Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                    continue;
                }

                PlaySelectedGame(choice);
            }
        }

        private void LoadOrCreateProfile()
        {
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Player";
            }

            string savedProfile = _saveLoadService.LoadData(playerName);
            
            if (savedProfile != null)
            {
                try
                {
                    var parts = savedProfile.Split(':', StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 2)
                    {
                        Console.WriteLine("Error: Invalid profile format. Expected 'Name: $Bank'.");
                        return;
                    }

                    string name = parts[0].Trim();
                    string bankPart = parts[1].Trim(); 

                    int dollarIndex = bankPart.IndexOf('$');
                    if (dollarIndex == -1)
                    {
                        Console.WriteLine("Error: Missing '$' symbol in bank amount.");
                        return;
                    }

                    string bankValueStr = bankPart.Substring(dollarIndex + 1).Trim();

                    if (!int.TryParse(bankValueStr, out int bank) || bank < 0)
                    {
                        Console.WriteLine($"Error: Invalid bank amount '{bankValueStr}'. Must be a non-negative integer.");
                        return;
                    }

                    _playerProfile = new PlayerProfile(name) { Bank = bank };
                    Console.WriteLine($"\nWelcome back, {_playerProfile.Name}! Loaded bank: ${_playerProfile.Bank}");
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading profile: {ex.Message}");
                }
            }
            else
            {
                _playerProfile = new PlayerProfile(playerName) { Bank = 1000 };
                string data = _playerProfile.Name+": $"+_playerProfile.Bank;
                _saveLoadService.SaveData(data, $"{_playerProfile.Name}");
            }
        }


        private void PlaySelectedGame(int gameChoice)
        {
            var game = _availableGames[gameChoice];

            int bet = GetValidBet();
            if (bet == 0) return;

            game.OnWin -= OnGameWin;
            game.OnLose -= OnGameLose;
            game.OnDraw -= OnGameDraw;

            game.OnWin += OnGameWin;
            game.OnLose += OnGameLose;
            game.OnDraw += OnGameDraw;

            Console.WriteLine($"\nStarting game with bet: ${bet}");
            Console.WriteLine("====================================");

            game.PlayGame(bet);
            SaveProfile();

            CheckBankLimits();
        }

        private int GetValidBet()
        {
            while (true)
            {
                Console.Write($"\nEnter your bet (1-{_playerProfile.Bank}): ");

                if (!int.TryParse(Console.ReadLine(), out int bet))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (bet < 1)
                {
                    Console.WriteLine("Bet must be at least $1.");
                    continue;
                }

                if (bet > _playerProfile.Bank)
                {
                    Console.WriteLine($"You cannot bet more than ${_playerProfile.Bank}!");
                    continue;
                }

                return bet;
            }
        }

        private void OnGameWin(int amount)
        {
            Console.WriteLine($"\nYou won ${amount}!");
            _playerProfile.Bank += amount;
        }

        private void OnGameLose(int amount)
        {
            Console.WriteLine($"\nYou lost ${amount}!");
            _playerProfile.Bank -= amount;
        }

        private void OnGameDraw(int amount)
        {
            Console.WriteLine($"\nIt's a draw! Your bet of ${amount} is returned.");
        }

        private void CheckBankLimits()
        {
            if (_playerProfile.Bank > MAX_BANK_VALUE)
            {
                Console.WriteLine("\n" + new string('*', 50));
                Console.WriteLine("CONGRATULATIONS!");
                Console.WriteLine($"You've exceeded the maximum bank limit of ${MAX_BANK_VALUE}!");
                Console.WriteLine("You broke the casino! A new one will be built in your honor!");
                Console.WriteLine($"Your winnings: ${_playerProfile.Bank - MAX_BANK_VALUE}");
                Console.WriteLine(new string('*', 50));

                _playerProfile.Bank = MAX_BANK_VALUE;
            }
            else if (_playerProfile.Bank > MAX_BANK_VALUE / 2)
            {
                Console.WriteLine("\nYou wasted half of your bank money in casino's bar");
                _playerProfile.Bank /= 2;
                Console.WriteLine($"Your bank is now: ${_playerProfile.Bank}");
            }
        }

        private void SaveProfile()
        {
            _saveLoadService.SaveData(_playerProfile.ToString(), _playerProfile.Name);
        }
    }
}