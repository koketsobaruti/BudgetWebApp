using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetWebApp.Classes
{
    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalDeposit { get; set; }
        public decimal InterestRate { get; set; }
        public int MONTHSTOPAY = 5;
        public decimal Insurance { get; set; }
        public decimal TotalVehiclePayment { get; set; }
        public decimal VehicleMonthlyPayment { get; set; }
    }
}