using System.Linq;
using BP.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace BP
{
    public class ScoreCalculator
    {


        public static void CalculateTotal(Performance p, BPContext context)
        {

            var scoring = context.ScoringSystem.Where(g => g.Position == p.Position)
                .FirstOrDefault();
            var match = context.Matches.Where(m => m.ID == p.MatchID).SingleOrDefault();
            p.GoalsConceeded = match.GoalsConceeded;
            p.CleanSheet = p.GoalsConceeded > 0 ? false : true;
            CalculateTotalPoints(p, scoring);
        }


        public static async System.Threading.Tasks.Task ReCalculateAllTotalsAsync(BPContext context)
        {
            var scoring = context.ScoringSystem.AsNoTracking().ToArray();

            foreach (var p in context.Performances)
            {
                CalculateTotalPoints(p, scoring.FirstOrDefault(g=> g.Position == p.Position));
            }
            var result = await context.SaveChangesAsync();
        }

        private static void CalculateTotalPoints(Performance p, Scoring scoring)
        {
            int total = 0;
            total += p.Appearance ? scoring.Appearance : 0;
            total += p.Assists * scoring.Assist;
            total += p.CleanSheet ? scoring.CleanSheet : 0;
            total += p.Goals * scoring.GoalScored;
            if(p.GoalsConceeded > 1 && (p.Position == Position.Defence || p.Position == Position.GoalKeeper))
            {
                total += Convert.ToInt32(Math.Floor(p.GoalsConceeded * -0.5));                
            }
            if (p.GoalsConceeded > 2 && p.Position == Position.Midfield)
            {
                if (p.GoalsConceeded > 6)
                    total -= 3;
                else if (p.GoalsConceeded > 4)
                    total -= 2;
                else if (p.GoalsConceeded > 2)
                    total -= 1;

            }


            total += p.MOTM ? scoring.MOTM : 0;
            total += p.PenaltiesMissed * scoring.PenMiss;
            total += p.PenaltiesSaved * scoring.PenSave;
            total += p.RedCard ? scoring.RedCard : 0;
            total += p.YellowCard ? scoring.YellowCard : 0;

            p.TotalPoints = total;
        }

    }
}
