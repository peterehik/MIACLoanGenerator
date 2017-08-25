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
        public CashFlowResponse GetLoanCashFlow(CashflowRequest request)
        {
            var response = new CashFlowResponse();
            foreach(var loan in request.Loans)
            {
                response.CashFlowItems.Add(GetLoanMonthyPayments(loan));
            }

            return response;
        }

        private List<MonthlyLoanDetail> GetLoanMonthyPayments(Loan loan)
        {
            var result = new List<MonthlyLoanDetail>();
            double remainingBalance = loan.Amount;
            double monthlyPayment = GetMonthlyPayment(loan.Amount, loan.Rate, loan.Months);

            for (int i = 0; i < loan.Months; i++)
            {
                double interest = remainingBalance * loan.Rate / 1200;
                double principal = monthlyPayment - interest;

                result.Add(new MonthlyLoanDetail()
                {
                    Month = i+1,
                    Interest = interest,
                    Principal = principal,
                    RemainingBalance = remainingBalance
                });

                remainingBalance -= principal;
            }

            return result;
        }

        private double GetMonthlyPayment(double amount, double rate, int months)
        {
            return amount * (rate) / (1 - (1 + rate / 1200) * months); ;
        }

    }
}
