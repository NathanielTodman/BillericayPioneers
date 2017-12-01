using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BP.Data;

namespace BP
{
    public class ScoreCalculator
    {

        public static void CalculateTotal(Performance p, BPContext context)
        {
            int total = 0;
            var scoring = context.ScoringSystem.Where(g => g.Position == p.Position)
                .FirstOrDefault();
            var match = context.Matches.Where(m => m.ID == p.MatchID).SingleOrDefault();
            p.GoalsConceeded = match.GoalsConceeded;
            p.CleanSheet = p.GoalsConceeded > 0 ? false : true;
            total += p.Appearance? scoring.Appearance: 0;
            total += p.Assists * scoring.Assist;
            total += p.CleanSheet ? scoring.CleanSheet : 0;
            total += p.Goals * scoring.GoalScored;
            if (p.GoalsConceeded > 5)
                total += scoring.ConceedFivePlus;
            else if (p.GoalsConceeded > 3)
                total +=  scoring.ConceedThreePlus;
            else if (p.GoalsConceeded > 1)
                total +=  scoring.ConceedOnePlus;

            total += p.MOTM ? scoring.MOTM : 0;
            total += p.PenaltiesMissed * scoring.PenMiss;
            total += p.PenaltiesSaved * scoring.PenSave;
            total += p.RedCard ? scoring.RedCard : 0;
            total += p.YellowCard ? scoring.YellowCard : 0;

            p.TotalPoints = total;
        }
    }
}
