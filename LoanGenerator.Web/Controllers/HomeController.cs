using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using LoanGenerator.BusinessLogic.Entities;
using LoanGenerator.BusinessLogic.LoanCalculators;
using LoanGenerator.BusinessLogic.RequestModels;
using LoanGenerator.Web.SessionManager;
using Microsoft.Ajax.Utilities;

namespace LoanGenerator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SessionLogic _sessionLogic = new SessionLogic();
        private readonly CalculatorLogic _calculatorLogic = new CalculatorLogic();

        public ActionResult Index()
        {
            return View(_sessionLogic.GetLoans());
        }

        public ActionResult ClearLoans()
        {
            _sessionLogic.ClearLoans();
            return RedirectToAction("Index");
        }

        public ActionResult AddLoan(Loan loan)
        {
            _sessionLogic.AddLoan(loan);
            return RedirectToAction("Index");
        }

        public PartialViewResult GetLoansPartial()
        {
            return PartialView("_Loans",_sessionLogic.GetLoans());
        }

        public PartialViewResult GetCashFlowPartial()
        {
            var loans = _sessionLogic.GetLoans();
            var cashflowResponse = _calculatorLogic.GetCashFlow(new CashflowRequest() {Loans = loans});
            return PartialView("_CashFlows", cashflowResponse);
        }
       
    }
}