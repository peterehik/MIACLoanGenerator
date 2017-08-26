using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoanGenerator.BusinessLogic.Entities;

namespace LoanGenerator.Web.SessionManager
{
    public class SessionLogic
    {
        private readonly List<Loan> _loans;
        private const string LockStr = "mySessionLoanLock";

        public SessionLogic()
        {
            var session = HttpContext.Current.Session;

            if (session["Loans"] == null)
            {
                session.Add("Loans", new List<Loan>());
            }

            _loans = session["Loans"] as List<Loan>;
        }

        public void AddLoan(Loan loan)
        {
            lock (LockStr)
            {
                _loans.Add(loan);
            }
        }

        public int CountLoans()
        {
            lock (LockStr)
            {
                return _loans.Count();
            }
        }

        public void ClearLoans()
        {
            lock(LockStr)
            {
                _loans.Clear();
            }
        }

        public List<Loan> GetLoans()
        {
            return _loans;
        } 
    }
}