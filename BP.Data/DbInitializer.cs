using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Data
{
    public class DbInitializer
    {
        public static void Initialize(BPContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Players.Any())
            {
                return;   // DB has been seeded
            }

            var players = new Player[]
            {
            new Player{FirstName="Shane",LastName="Coe", Number=1},
            new Player{FirstName="Matt",LastName="Bolton", Number=4},
            new Player{FirstName="Matt",LastName="Orchard", Number=5},
            new Player{FirstName="Paul",LastName="Haynes", Number=6},
            new Player{FirstName="Luke",LastName="Haynes", Number=7},
            new Player{FirstName="Ian",LastName="Goulding", Number=8},
            new Player{FirstName="Andrew",LastName="Brinkman", NickName="Wiggy", Number=9},
            new Player{FirstName="James",LastName="Reader", Number=10},
            new Player{FirstName="Nick",LastName="Ellis", Number=11},
            new Player{FirstName="Tim",LastName="Butt", Number=12},
            new Player{FirstName="Neil",LastName="Haynes", Number=56},
            new Player{FirstName="Joe",LastName="Ellis", Number=14},
            new Player{FirstName="Jon",LastName="Ellis", Number=15},
            new Player{FirstName="George",LastName="Ward", Number=16},
            new Player{FirstName="Rob",LastName="Coe"},
            new Player{FirstName="John",LastName="H"},
            new Player{FirstName="Scott",LastName="Houghton"},
            new Player{FirstName="Nat",LastName="Todman"},
            };
            foreach (var s in players)
            {
                context.Players.Add(s);
            }

            var scorings = new Scoring[]
            {
                new Scoring{
                    Position = Position.GoalKeeper,
                    Appearance=1,
                    GoalScored = 6,
                    CleanSheet =4,
                    Assist = 2,
                    ConceedOnePlus = -1,
                    ConceedThreePlus = -1,
                    ConceedFivePlus = -1,
                    PenSave = 6,
                    PenMiss = -1,
                    MOTM = 4,
                    YellowCard = -2,
                    RedCard = -5
                  },new Scoring{
                    Position = Position.Defence,
                    Appearance=1,
                    GoalScored = 5,
                    CleanSheet =4,
                    Assist = 2,
                    ConceedOnePlus = -1,
                    ConceedThreePlus = -1,
                    ConceedFivePlus = -1,
                    PenSave = 6,
                    PenMiss = -1,
                    MOTM = 4,
                    YellowCard = -2,
                    RedCard = -5
                  },new Scoring{
                    Position = Position.Midfield,
                    Appearance=1,
                    GoalScored = 4,
                    CleanSheet =1,
                    Assist = 2,
                    ConceedOnePlus = -0,
                    ConceedThreePlus = -1,
                    ConceedFivePlus = -1,
                    PenSave = 6,
                    PenMiss = -2,
                    MOTM = 4,
                    YellowCard = -2,
                    RedCard = -5
                  },new Scoring{
                    Position = Position.Forward,
                    Appearance=1,
                    GoalScored = 3,
                    CleanSheet =0,
                    Assist = 2,
                    ConceedOnePlus = 0,
                    ConceedThreePlus = 0,
                    ConceedFivePlus = 0,
                    PenSave = 6,
                    PenMiss = -3,
                    MOTM = 4,
                    YellowCard = -2,
                    RedCard = -5
                  },
            };
            context.ScoringSystem.AddRange(scorings);

            var teams = new Team[]
            {
                new Team{                    
                    TeamName = "Central Baptist",
                    Draws= 2,
                    GoalDifference = 0,
                    GoalsAgainst = 2,
                    GoalsFor =2 , Losses = 0, Points= 2, Wins = 0

                }, new Team{

                    TeamName = "Billericay Pioneers",
                    Draws= 1,
                    GoalDifference = 2,
                    GoalsAgainst = 2,
                    GoalsFor =4 ,
                    Losses = 0,
                    Points = 4,
                    Wins = 1

                }
            };
            context.Teams.AddRange(teams);

            context.SaveChanges();
        }
    }
}
