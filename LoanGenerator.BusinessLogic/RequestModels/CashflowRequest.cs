using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanGenerator.BusinessLogic.Entities;

namespace LoanGenerator.BusinessLogic.RequestModels
{
    public class CashflowRequest
    {
        public List<Loan> Loans { get; set; }
    }
}
