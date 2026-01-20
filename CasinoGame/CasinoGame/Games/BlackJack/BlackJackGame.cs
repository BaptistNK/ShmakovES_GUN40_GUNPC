namespace CasinoGame.Games.BlackJack
{
    class BlackJackGame : CasinoGameBase
    {
        public BlackJackGame(int numberOfCards)
        {
            if (numberOfCards <= 0)
            {
                throw new ArgumentException("Number of cards > 0", nameof(numberOfCards));
            }
            var cards = CreateCards(numberOfCards);
            Shuffle(cards);
        }
        private List<Card> CreateCards(int count)
        {
            var cards = new List<Card>();
            var suits = (Suits[])Enum.GetValues(typeof(Suits));
            var ranks = (Ranks[])Enum.GetValues(typeof(Ranks));

            int totalAvailable = 36;
            int cardsToCreate = Math.Min(count, totalAvailable);
            for (int i = 0; i < cardsToCreate; i++)
            {
                Suits suit = suits[i % suits.Length];
                Ranks rank = ranks[i % ranks.Length];
                cards.Add(new Card(suit, rank));
            }
                return cards;
        }
        private Queue<Card> Deck { get; } = new Queue<Card>();
        private void Shuffle(List<Card> cards)
        {
            var _random = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }

            foreach (var card in cards)
            {
                Deck.Enqueue(card);
            }
        }

        public override void PlayGame()
        {
            throw new NotImplementedException();
        }

        protected override void FactoryMethod()
        {
            throw new NotImplementedException();
        }
    }
}
