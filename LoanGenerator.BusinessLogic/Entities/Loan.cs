using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanGenerator.BusinessLogic.Entities
{
    public class Loan
    {
        public double Amount { get; set; }
        public int Months { get; set; }
        public double Rate { get; set; }
    }
}
