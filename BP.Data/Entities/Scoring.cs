using System.ComponentModel.DataAnnotations;

namespace BP.Data
{
    public class Scoring
    {
        [Key]
        public Position Position { get; set; }
        public int Appearance { get; set; }
        public int GoalScored { get; set; }
        public int CleanSheet { get; set; }
        public int Assist { get; set; }
        public int ConceedOnePlus { get; set; }
        public int ConceedThreePlus { get; set; }
        public int ConceedFivePlus { get; set; }
        public int PenSave { get; set; }
        public int PenMiss { get; set; }
        public int MOTM { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }

    }

    public enum Position
    {
        GoalKeeper, Defence, Midfield, Forward
    }
}
