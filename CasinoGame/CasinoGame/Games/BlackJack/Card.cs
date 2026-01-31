namespace CasinoGame.Games.BlackJack
{
    public enum CardSuit
    {
        Diamonds,
        Hearts,
        Clubs,
        Spades
    }

    public enum CardRank
    {
        Six = 6,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public struct Card
        {
            public CardSuit Suit { get; }
            public CardRank Rank { get; }

            public Card(CardSuit suit, CardRank rank)
            {
                Suit = suit;
                Rank = rank;
            }

            public override string ToString()
            {
                return $"{Rank} of {Suit}";
            }
        }
    
}
