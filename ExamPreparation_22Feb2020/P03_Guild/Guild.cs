using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    class Guild
    {

        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get => roster.Count;
        }

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player playerToRemove = roster.FirstOrDefault(p => p.Name == name);

            return roster.Remove(playerToRemove);
        }

        public void PromotePlayer(string name)
        {
            Player playerToPromote = roster.FirstOrDefault(p => p.Name == name);
            if (playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player playerToPromote = roster.FirstOrDefault(p => p.Name == name);
            if (playerToPromote.Rank != "Trial")
            {
                playerToPromote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string _class)
        {
            Player[] removedPlayesArr = roster
                .Where(p => p.Class == _class)
                .ToArray();            
            roster.RemoveAll(p => p.Class == _class);

            return removedPlayesArr;
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Players in the guild: {Name}");
            result.AppendLine(string.Join(Environment.NewLine, roster));
            return result.ToString().TrimEnd();
        }
    }
}
