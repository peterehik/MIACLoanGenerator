using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanGenerator.BusinessLogic.RequestModels
{
    public class CashFlowResponse
    {
        public List<CashFlowLoanItem> CashFlowItems { get; set; }
        public CashFlowLoanItem PoolLevel { get; set; }

        public CashFlowResponse()
        {
            CashFlowItems = new List<CashFlowLoanItem>();
        }
    }

    public class CashFlowLoanItem
    {
        public string Title { get; set; }
        public List<MonthlyCashFlowItem> Values { get; set; } 
    }
}
