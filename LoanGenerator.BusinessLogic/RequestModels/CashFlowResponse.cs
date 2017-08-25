using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanGenerator.BusinessLogic.RequestModels
{
    public class CashFlowResponse
    {
        public List<List<MonthlyLoanDetail>> CashFlowItems { get; set; } 
    }
}
