using LoanGenerator.BusinessLogic.Entities;
using LoanGenerator.BusinessLogic.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanGenerator.BusinessLogic.LoanCalculators
{
    public class CalculatorLogic
    {
        public CashFlowResponse GetCashFlow(CashflowRequest request)
        {
            var response = new CashFlowResponse();
            var poolLevel = new Dictionary<int, MonthlyCashFlowItem>();

            int i = 1;
            foreach(var loan in request.Loans)
            {
                response.CashFlowItems.Add(new CashFlowLoanItem()
                {
                    Values = GetLoanMonthyPayments(loan, poolLevel),
                    Title = "Loan " + i++
                });
            }

            response.PoolLevel = new CashFlowLoanItem()
            {
                Title = "Pool Level",
                Values = poolLevel.Values.ToList()
            };

            return response;
        }

        private List<MonthlyCashFlowItem> GetLoanMonthyPayments(Loan loan, Dictionary<int, MonthlyCashFlowItem> poolLevelDictionary)
        {
            var result = new List<MonthlyCashFlowItem>();
            double remainingBalance = loan.Amount;
            double monthlyPayment = GetMonthlyPayment(loan.Amount, loan.Rate, loan.Months);

            for (int i = 0; i < loan.Months; i++)
            {
                double interest = remainingBalance * loan.Rate / 1200;
                double principal = monthlyPayment - interest;

                var entity = new MonthlyCashFlowItem()
                {
                    Month = i + 1,
                    Interest = interest,
                    Principal = principal,
                    RemainingBalance = remainingBalance
                };

                MonthlyCashFlowItem poolEntity;
                if (poolLevelDictionary.ContainsKey(entity.Month))
                {
                    poolEntity = poolLevelDictionary[entity.Month];
                }
                else
                {
                    poolEntity = new MonthlyCashFlowItem() {Month = entity.Month};
                    poolLevelDictionary.Add(entity.Month, poolEntity);
                }

                poolEntity.Interest += entity.Interest;
                poolEntity.Principal += entity.Principal;
                poolEntity.RemainingBalance += entity.RemainingBalance;

                result.Add(entity);

                remainingBalance -= principal;
            }

            return result;
        }

        private double GetMonthlyPayment(double amount, double rate, int months)
        {
            return (amount)*(rate/1200)/(1 - Math.Pow((1 + rate/1200), (-1*months)));
        }

    }
}
