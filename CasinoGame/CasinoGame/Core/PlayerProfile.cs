namespace CasinoGame.Core
{
    public class PlayerProfile
    {
        public string Name { get; set; }
        public int Bank { get; set; }

        public PlayerProfile(string name)
        {
            Name = name;
            Bank = 1000; 
        }

        public override string ToString()
        {
            return $"{Name}: ${Bank}";
        }
    }

}
