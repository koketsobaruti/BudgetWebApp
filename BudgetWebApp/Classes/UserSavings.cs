using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetWebApp.Classes
{
    public class UserSavings
    {
        public string Reason { get; set; }
        public double Investment { get; set; }
        public double InterestRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SavingsGoal { get; set; }
        public string InterestMethod { get; set; }
    }
}