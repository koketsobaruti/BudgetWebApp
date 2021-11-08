using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetWebApp.Classes
{
    public class Expenses:Home
    {
        //get set methods
        public decimal Groceries { get; set; }
        public decimal Utilities { get; set; }
        public decimal Travel { get; set; }
        public decimal Communication { get; set; }

        public IDictionary<string, double> OtherExpenses { get; set; }

        public decimal RentalAmount { get; set; }
    }

    public abstract class Home
    {

        public decimal PurchasePrice { get; set; }
        public decimal Deposit { get; set; }
        public decimal Interest { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal MonthlyPayment { get; set; }
        public int MonthsToPay { get; set; }
    }
}