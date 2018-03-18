using System;

namespace BP.Data
{
    public class Match
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public bool PlayedAtHome { get; set; }
        public int OpositionID { get; set; }
        public Team Oposition { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public Competition Competition { get; set; }

        public string MatchName
        {
            get
            {
                string ourTeam = "Billericay Pioneers";
                if (Oposition != null)
                {
                    if (PlayedAtHome)
                    {
                        return ourTeam + " v " + Oposition.TeamName;
                    }
                    return Oposition.TeamName + " v " + ourTeam;
                }
                return "";
            }
        }

        public int GoalsConceeded
        {
            get
            {
                if (PlayedAtHome)
                {
                    return AwayScore;
                }
                return HomeScore;
            }
        }

    }
    public enum Competition { League, Cup, Friendly }

}
