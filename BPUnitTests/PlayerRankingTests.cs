using BP.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace BPUnitTests
{
    public class PlayerRankingTests
    {
        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<BPContext>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BillericayPioneers;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            using (var context = new BPContext(options))
            {
                var players = context.Players.Include(g=>g.Performances)
                    .ToArray();


        }
    }
}
}
