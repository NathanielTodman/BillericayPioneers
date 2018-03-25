using BP.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Models
{
    public class PaymentViewModel
    {
        public IEnumerable<Match> Matches { get; set; }
        public Player[] Players { get; set; }

        public PaymentViewModel()
        {
            using (var context = new BPContext())
            {
                var accounts = context.Matches
                    .AsNoTracking()
                    .Include(g => g.Oposition)
                    .Include(g => g.Performances).ThenInclude(g => g.Player)
                    .ToList();

                Matches = accounts;
                Players = context.Players.AsNoTracking()
                    .OrderBy(g => g.FirstName)
                    .ToArray();
            }
        }
    }
}
