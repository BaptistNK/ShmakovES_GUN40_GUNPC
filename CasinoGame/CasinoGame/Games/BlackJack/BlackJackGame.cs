using CasinoGame.Games.BlackJack;
using CasinoGame.Games;

namespace CasinoApp.Games.Blackjack
{
    public class BlackjackGame : CasinoGameBase
    {
        private readonly int _numberOfCards;
        private Queue<Card> _deck;
        private List<Card> _allCards;

        public BlackjackGame(int numberOfCards)
        {
            if (numberOfCards < 4)
                throw new ArgumentException("At least 4 cards are required", nameof(numberOfCards));

            _numberOfCards = numberOfCards;
            _allCards = new List<Card>();
            _deck = new Queue<Card>();
        }

        protected override void FactoryMethod()
        {
            CreateCards();
            Shuffle();
        }

        private void CreateCards()
        {
            var suits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>().ToArray();
            var ranks = Enum.GetValues(typeof(CardRank)).Cast<CardRank>().ToArray();

            int cardsCreated = 0;
            while (cardsCreated < _numberOfCards)
            {
                foreach (var suit in suits)
                {
                    foreach (var rank in ranks)
                    {
                        if (cardsCreated >= _numberOfCards)
                            break;

                        _allCards.Add(new Card(suit, rank));
                        cardsCreated++;
                    }

                    if (cardsCreated >= _numberOfCards)
                        break;
                }
            }
        }

        private void Shuffle()
        {
            var random = new Random();
            var shuffledCards = _allCards.OrderBy(x => random.Next()).ToList();
            _deck = new Queue<Card>(shuffledCards);
        }

        public override void PlayGame(int bet)
        {
            FactoryMethod();
            if (_deck.Count < 4)
            {
                Console.WriteLine("Not enough cards in deck!");
                OnLoseInvoke(bet);
                return;
            }

            var playerCards = DealCards(2);
            var computerCards = DealCards(2);

            Console.WriteLine("Your cards:");
            foreach (var card in playerCards)
            {
                Console.WriteLine($"  {card}");
            }

            Console.WriteLine("\nComputer's cards:");
            foreach (var card in computerCards)
            {
                Console.WriteLine($"  {card}");
            }

            var playerScore = CalculateScore(playerCards);
            var computerScore = CalculateScore(computerCards);

            Console.WriteLine($"\nYour score: {playerScore}");
            Console.WriteLine($"Computer's score: {computerScore}");

            DetermineWinner(playerScore, computerScore, bet);
        }

        private List<Card> DealCards(int count)
        {
            var cards = new List<Card>();
            for (int i = 0; i < count; i++)
            {
                if (_deck.Count > 0)
                {
                    cards.Add(_deck.Dequeue());
                }
            }
            return cards;
        }

        private int CalculateScore(List<Card> cards)
        {
            int score = 0;
            int aces = 0;

            foreach (var card in cards)
            {
                if (card.Rank >= CardRank.Jack && card.Rank <= CardRank.King)
                {
                    score += 10;
                }
                else if (card.Rank == CardRank.Ace)
                {
                    aces++;
                    score += 11;
                }
                else
                {
                    score += (int)card.Rank;
                }
            }

            while (score > 21 && aces > 0)
            {
                score -= 10;
                aces--;
            }

            return score;
        }

        private void DetermineWinner(int playerScore, int computerScore, int bet)
        {
            if (playerScore == computerScore)
            {
                if (playerScore < 21 && _deck.Count >= 2)
                {
                    Console.WriteLine("\nDraw! Dealing one more card each...");
                    var extraPlayerCard = DealCards(1);
                    var extraComputerCard = DealCards(1);

                    playerScore += CalculateScore(extraPlayerCard);
                    computerScore += CalculateScore(extraComputerCard);

                    Console.WriteLine($"Your new score: {playerScore}");
                    Console.WriteLine($"Computer's new score: {computerScore}");

                    DetermineWinner(playerScore, computerScore, bet);
                }
                else
                {
                    Console.WriteLine("\nIt's a draw!");
                    OnDrawInvoke(bet);
                }
            }
            else if (playerScore > 21 && computerScore > 21)
            {
                Console.WriteLine("\nBoth bust! Draw!");
                OnDrawInvoke(bet);
            }
            else if (playerScore > 21)
            {
                Console.WriteLine("\nYou bust! Computer wins!");
                OnLoseInvoke(bet);
            }
            else if (computerScore > 21)
            {
                Console.WriteLine("\nComputer busts! You win!");
                OnWinInvoke(bet);
            }
            else if (playerScore > computerScore)
            {
                Console.WriteLine("\nYou win!");
                OnWinInvoke(bet);
            }
            else
            {
                Console.WriteLine("\nComputer wins!");
                OnLoseInvoke(bet);
            }
        }
    }
}