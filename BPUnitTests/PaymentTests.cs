using BP.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BPUnitTests
{
    public class PaymentTests
    {


        [Fact]
        public void MyTestMethod()
        {
            using (var context = new BPContext())
            {
                var accounts = context.Matches
                    .AsNoTracking()
                    .Include(g=>g.Oposition)
                    .Include(g=>g.Performances)
                    .ToList();
            }

        }
    }
}
