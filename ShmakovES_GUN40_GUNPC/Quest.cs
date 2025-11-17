using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShmakovES_GUN40_GUNPC
{
    public class Quest
    {
        public string Title { get; }
        public string Description { get; }
        public int Reward {  get; }
        public bool IsCompleted  { get; private set; }=false;
        public Quest()
        {
            Title = "Unknown Quest";
            Description = "No description.";
            Reward = 0;
        }
        public Quest(string title, string description, int reward)
        {
            Title = title;
            Description = description;
            Reward = reward;
        }
        public string Complete()
        {
            IsCompleted = true;
            return "Quest ‘{Title}’ completed! Reward: {Reward} gold.";
        }

        public string Fail()
        {
            IsCompleted = false;
            return "Quest ‘{Title}’ failed.";
        }
        public bool IsEligible(int playerLevel)
        {
            return playerLevel >= Reward / 10; 
        }
    }
}
