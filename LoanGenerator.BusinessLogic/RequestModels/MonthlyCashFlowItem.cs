﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanGenerator.BusinessLogic.RequestModels
{
    public class MonthlyCashFlowItem
    {
        public int Month { get; set; }
        public double RemainingBalance { get; set; }
        public double Interest { get; set; }
        public double Principal { get; set; }
    }
}
