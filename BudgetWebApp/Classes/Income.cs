using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetWebApp.Classes
{
    public class Income
    {
        /// <summary>
        /// Gets or sets the grossIncome.
        /// </summary>
        public decimal GrossIncome { get; set; }

        /// <summary>
        /// Gets or sets the tax.
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// Gets or sets the incomeAfterTax.
        /// </summary>
        public decimal IncomeAfterTax { get; set; }

        /// <summary>
        /// Gets or sets the netIncome.
        /// </summary>
        public decimal NetIncome { get; set; }

        /// <summary>
        /// Gets or sets the totalExpenses.
        /// </summary>
        public decimal TotalExpenses { get; set; }
    }
}