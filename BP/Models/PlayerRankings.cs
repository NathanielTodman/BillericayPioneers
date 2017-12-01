using BP.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Models
{
    public class PlayerRankings
    {
        [Display]
        public string Name { get; set; }
        [Display]
        public double? Points { get; set; }
        [Display(Name= "Average Per Game")]
        public double? AveragePerGame { get; set; }
        [Display(Name= "Strongest Position")]
        public string StrongestPosition { get; set; }
        [Display]
        public int? Goals { get; set; }
        [Display]
        public int? Assists { get; set; }
        [Display (Name="Yellow Cards")]
        public int? YellowCards { get; set; }
        [Display(Name = "Red Cards")]
        public int? RedCards { get; set; }
        [Display(Name = "Games Played")]
        public int? GamesPlayed { get; set; }
        private Performance[] LastFivePerformances { get; set; }

        public PlayerRankings()
        {

        }

        public static async Task<IEnumerable<PlayerRankings>> GetAllPlayerRankings(BPContext context)
        {
            List<PlayerRankings> playerRankings = new List<PlayerRankings>();
            var players = await context.Players
                            .AsNoTracking()
                            .Include(g => g.Performances)
                            .ThenInclude(Performance => Performance.Match)                            
                            .ToArrayAsync();


            foreach (var player in players.Where(g=>g.Performances.Count>0))
            {
                var temp = new PlayerRankings()
                {
                    Name = player.FullName,
                    Points = player.Performances?.Sum(g => g.TotalPoints),
                    AveragePerGame = player.Performances?.Average(g => g.TotalPoints),
                    StrongestPosition = player.Performances?.OrderByDescending(g => g.TotalPoints).First().Position.ToString(),
                    Goals = player.Performances?.Sum(g => g.Goals),
                    Assists = player.Performances?.Sum(g => g.Assists),
                    YellowCards = player.Performances?.Sum(g => g.Assists),
                    RedCards = player.Performances?.Sum(g => g.Assists),
                    GamesPlayed = player.Performances?.Count,
                    LastFivePerformances = player.Performances?.TakeLast(5).ToArray()
                };
                playerRankings.Add(temp);
            }

            return playerRankings.OrderByDescending(p=>p.Points).ToArray();
        }
    }
}
