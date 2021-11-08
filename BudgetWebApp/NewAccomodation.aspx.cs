using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using BudgetWebApp.Classes;

namespace BudgetWebApp
{
    public partial class NewAccomodation : System.Web.UI.Page
    {
        //Variable declaration
        private decimal _monthlyIncome, _purchase, _deposit, _interest;
        private int _months;
        private Income _incomePassed;
        private Income _income;
        private string _accomodationType;
        private Expenses homeExpenses;
        private bool eligibility = false;
        Income income;

        protected void Page_Load(object sender, EventArgs e)
        {
            string g = "";
            //if (!IsPostBack)
            if (Session["username"] != null)
            {
                g = Session["username"].ToString();
            }

            username.Value = g;
            // lblConfirm.Visible = false;
            Panel1.Enabled = false;
            Panel2.Enabled = false;
            btnSubmitHome.Enabled = false;
            rentConfirm.Visible = false;
        }

        protected void btnRent_Click(object sender, EventArgs e)
        {
            if (!rentTxt.Text.IsEmpty())
            {
                rentConfirm.Visible = true;
                Thread addRent = new Thread(AddRent);
                addRent.Start();
                Expenses expenses = new Expenses();
                expenses = GeneralExpensesDb.GetExpenses(username.Value);
                decimal subtotal = expenses.Groceries + expenses.Utilities + expenses.Communication +
                                   expenses.Travel;

                bool found = OtherExpensesDb.FindEntry(username.Value);

                if (found)
                {
                    decimal otherTotal = OtherExpensesDb.GetSum(username.Value);
                    decimal totalExp = otherTotal + subtotal;
                    decimal afterTax = IncomeDb.GetTotalExpense(username.Value);

                    decimal net = Calculations.IncomeCalculations.NetIncome(afterTax, totalExp, Convert.ToDecimal(rentTxt.Text));

                    income = new Income
                    {
                        NetIncome = net,
                        TotalExpenses = totalExp
                    };


                }
                else
                {
                    decimal total = subtotal;
                    decimal afterTax = IncomeDb.GetTotalExpense(username.Value);

                    decimal net = Calculations.IncomeCalculations.NetIncome(afterTax, total, Convert.ToDecimal(rentTxt.Text));

                    income = new Income
                    {
                        NetIncome = net,
                        TotalExpenses = total
                    };

                }
                Thread addIncome = new Thread(() => AddIncome(income));
                addIncome.Start();


            }



        }

        public void AddRent()
        {
            RentalDB.AddRental(username.Value,Convert.ToDecimal(rentTxt.Text));
        }
       

        protected void btnRentOption_Click(object sender, EventArgs e)
        {
            //make a thread to disable the house panel
            Thread threadDisable=new Thread(()=> MakeDisabled(Panel2));
            threadDisable.Start();

            //change the colors of the button when they are clicked on
            btnRentOption.BackColor = System.Drawing.Color.OrangeRed;
            btnBuyOption.BackColor = System.Drawing.Color.LightSteelBlue;
            Panel1.Enabled = true;
            _accomodationType = "rent";
            //Add to the rent database;

            btnEligibility.BackColor = System.Drawing.Color.LightSteelBlue;
            btnRent.BackColor = System.Drawing.Color.Green;
            
        }

        protected void btnBuyOption_Click(object sender, EventArgs e)
        {
            //make a thread to disable the rental panel
            Thread threadDisable = new Thread(() => MakeDisabled(Panel1));
            threadDisable.Start();

            //change the colors of the button when they are clicked on
            btnRentOption.BackColor = System.Drawing.Color.LightSalmon;
            btnBuyOption.BackColor = System.Drawing.Color.MediumBlue;
            btnEligibility.BackColor = System.Drawing.Color.MediumBlue;
            btnRent.BackColor = System.Drawing.Color.LightGreen;
            Panel2.Enabled = true;
            _accomodationType = "house";
        }

        protected void btnSubmitHome_Click(object sender, EventArgs e)
        {
            //add a home loan because the use has qualified
            

            var expenses = new Expenses();
            expenses = GeneralExpensesDb.GetExpenses(username.Value);
            decimal subtotal = expenses.Groceries + expenses.Utilities + expenses.Communication +
                               expenses.Travel;

            decimal monthlyCost = Calculations.PaymentsCalculations.MonthlyPaymentCalculation(Convert.ToInt32(txtPaymentMonths.Text),
                Convert.ToDecimal(txtPurchase.Text), Convert.ToDecimal(txtInterest.Text), Convert.ToDecimal(txtDeposit.Text));

            decimal totalCost = Calculations.PaymentsCalculations.TotalPaymentCalculation(Convert.ToInt32(txtPaymentMonths.Text),
                Convert.ToDecimal(txtPurchase.Text), Convert.ToDecimal(txtInterest.Text), Convert.ToDecimal(txtDeposit.Text));

            homeExpenses = new Expenses
            {
                PurchasePrice = Convert.ToDecimal(txtPurchase.Text),
                Deposit = Convert.ToDecimal(txtDeposit.Text),
                Interest = Convert.ToDecimal(txtInterest.Text),
                MonthsToPay = Convert.ToInt32(txtPaymentMonths.Text),
                MonthlyPayment = monthlyCost,
                TotalPayment = totalCost
            };
            Thread addHomeThread = new Thread(AddHome);
            addHomeThread.Start();
            decimal afterTax = IncomeDb.GetTotalExpense(username.Value);

            decimal net = Calculations.IncomeCalculations.NetIncome(afterTax, subtotal, monthlyCost);

            income = new Income
            {
                NetIncome = net,
                TotalExpenses = subtotal
            };

            Thread addIncome = new Thread(() => AddIncome(income));
            addIncome.Start();

            houseConfirmation.Text = "You have successfully added your home loan details!";
        }

        //method to make the specified panel enabled
        public void MakeDisabled(Panel panel)
        {
            if (panel.Enabled)
                panel.Enabled = false;

        }

        protected void rentTxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnEligibility_Click(object sender, EventArgs e)
        {

            _purchase = Convert.ToDecimal(txtPurchase.Text);
            _deposit = Convert.ToDecimal(txtDeposit.Text);
            _interest = Convert.ToDecimal(txtInterest.Text);
            _months = Convert.ToInt32(txtPaymentMonths.Text);

            var h = new Expenses
            {
                PurchasePrice = _purchase,
                Deposit = _deposit,
                Interest = _interest,
                MonthsToPay = _months
            };
            _monthlyIncome = IncomeDb.GetGrossIncome(username.Value);

            if (_months > 239 && _months < 361)
            {
                houseConfirmation.Visible = true;

                //Get the eligibility of the user for a house loan
                bool eligibility = Calculations.PaymentsCalculations.HomeLoanEligability(_monthlyIncome, _purchase, _interest, _months, _deposit);
                if (eligibility)
                {
                    
                    houseConfirmation.Text = "You qualify for a house loan.";
                    btnSubmitHome.BackColor = System.Drawing.Color.Green;
                    btnSubmitHome.Enabled = true;
                }

                else
                {
                    houseConfirmation.Text = "You do not qualify for a house loan. The monthly loan repayment is more than a third of your income.";
                }
            }
            else
            {
                houseConfirmation.Visible = true;
                houseConfirmation.Text = "The months you have to pay should only be between 240 and 360.";
            }

        }

        protected void btnVehicle_Click(object sender, EventArgs e)
        { 
           
                Session["username"] = username.Value;
                Response.Redirect("AddVehicle.aspx");
            
        }


        /// <summary>
        /// method used to add the income user to the database if they have added all their accommodation details
        /// </summary>
        public static Income Proceed(Income inc,string name, decimal afterTax, decimal totalExpenses)
        {
            decimal net = NetCalculation(afterTax, totalExpenses,name);

            Income income = new Income
            {
                NetIncome = net,
                TotalExpenses = inc.TotalExpenses
            };
            return income;
        }


        /// <summary>
        ///method to add user's income to the database
        /// </summary>
        public void AddIncome(Income i)
        {
            IncomeExpensesDb.AddIncome(username.Value, i);
        }

        /// <summary>
        /// method to check if the user qualifies for a home loan
        /// </summary>
        /// <returns></returns>
        public bool GetEligibility()
        {
            bool el =
                Calculations.PaymentsCalculations.HomeLoanEligability(_monthlyIncome, _purchase, _interest, _months,
                    _deposit);
            return el;
        }

        /// <summary>
        /// method to load home loan information into the database
        /// </summary>
        public void AddHome()
        {
            HomeLoanDb.AddHomeLoan(username.Value, homeExpenses);
        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            Session["username"] = username.Value;
            Response.Redirect("Homepage.aspx");
        }

        protected void OKButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        

        /// <summary>
        /// method containing functions used to get the net income and find out the cost of the user's specified accommodation
        /// </summary>
        /// <returns></returns>
        public static decimal NetCalculation(decimal afterTax, decimal totalExpenses,string username)
        {
            decimal accommodationCost = GetCost(username);
            //calculate the total remaining after all expenses have been deducted from the original monthly income
            decimal netCost = Calculations.IncomeCalculations.NetIncome(afterTax, totalExpenses, accommodationCost);
            return netCost;
        }

        /// <summary>
        /// method to get the accommodation cost
        /// </summary>
        /// <returns></returns>
        public static decimal GetCost(string username)
        {
            decimal cost=0;
            bool rentalUser = RentalDB.FindRentalUser(username);
            bool houseUser = HomeLoanDb.FindHouseUser(username);
            if (rentalUser)
            {
                cost = RentalDB.GetRentalAmount(username);
            }else if(houseUser){ cost = HomeLoanDb.GetHouseAmount(username); }
                

            return cost;
        }

        /// <summary>
        /// check if the user added their accommodation details into the database before moving onto the next page
        /// </summary>
        /// <returns></returns>
        public static bool CheckUser(string name)
        {
            bool found = false;
            bool rentalUser = RentalDB.FindRentalUser(name);
            bool houseUser = HomeLoanDb.FindHouseUser(name);

            if ((rentalUser) || (houseUser))
                found = true;

            return found;
        }
    }
}