namespace BP.Data
{
    public class Performance
    {
        public int ID { get; set; }
        public int PlayerID { get; set; }
        public int MatchID { get; set; }
        public Player Player { get; set; }
        public Match Match { get; set; }
        public Position Position { get; set; }
        public bool Appearance { get; set; }
        public int Goals { get; set; }
        public bool CleanSheet { get; set; }
        public int Assists { get; set; }
        public int GoalsConceeded { get; set; }
        public int PenaltiesSaved { get; set; }
        public int PenaltiesMissed { get; set; }
        public bool MOTM { get; set; }
        public bool YellowCard { get; set; }
        public bool RedCard { get; set; }
        public int TotalPoints { get; set; }
    }
}
