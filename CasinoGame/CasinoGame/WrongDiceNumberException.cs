namespace CasinoGame
{
    public class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(int invalidNumber, int min, int max)
            : base($"Invalid dice number: {invalidNumber}. Allowed range is {min} to {max}.")
        {
            InvalidNumber = invalidNumber;
            MinAllowed = min;
            MaxAllowed = max;
        }

        public int InvalidNumber { get; }
        public int MinAllowed { get; }
        public int MaxAllowed { get; }
    }
}
