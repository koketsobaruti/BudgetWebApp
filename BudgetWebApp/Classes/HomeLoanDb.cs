using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BudgetWebApp.Classes
{
    public class HomeLoanDb
    {
        public static void AddHomeLoan(string name, Expenses home)
        {
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("INSERT INTO TBL_HOUSELOAN(FK_USERNAME,HOUSE_PURCHASE_PRICE,HOUSE_DEPOSIT," +
                            "HOUSE_INTEREST,MONTHS_TO_PAY,MONTHLY_PAYMENT,TOTAL_PAYMENT) " +
                            "VALUES (@FK_USERNAME,@HOUSE_PURCHASE_PRICE,@HOUSE_DEPOSIT," +
                            "@HOUSE_INTEREST,@MONTHS_TO_PAY,@MONTHLY_PAYMENT,@TOTAL_PAYMENT)", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);
                        command.Parameters.AddWithValue("@HOUSE_PURCHASE_PRICE", home.PurchasePrice);
                        command.Parameters.AddWithValue("@HOUSE_DEPOSIT", home.Deposit);
                        command.Parameters.AddWithValue("@HOUSE_INTEREST", home.Interest);
                        command.Parameters.AddWithValue("@MONTHS_TO_PAY", home.MonthsToPay);
                        command.Parameters.AddWithValue("@MONTHLY_PAYMENT", home.MonthlyPayment);
                        command.Parameters.AddWithValue("@TOTAL_PAYMENT", home.TotalPayment);

                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex) { throw ex; }
                    finally
                    {
                        connection.Close();
                    }
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
            }
        }
        public static Expenses GetHomeLoan(string name)
        {
            Expenses home = new Expenses();
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("SELECT HOUSE_PURCHASE_PRICE,HOUSE_DEPOSIT," +
                                                     "HOUSE_INTEREST,MONTHS_TO_PAY,MONTHLY_PAYMENT,TOTAL_PAYMENT FROM TBL_HOUSELOAN " +
                                                     "WHERE FK_USERNAME=@FK_USERNAME", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                home = new Expenses
                                {
                                    PurchasePrice = Convert.ToDecimal(reader["HOUSE_PURCHASE_PRICE"]),
                                    Deposit = Convert.ToDecimal(reader["HOUSE_DEPOSIT"]),
                                    Interest = Convert.ToDecimal(reader["HOUSE_INTEREST"]),
                                    MonthsToPay = Convert.ToInt32(reader["MONTHS_TO_PAY"]),
                                    MonthlyPayment = Convert.ToDecimal(reader["MONTHLY_PAYMENT"]),
                                    TotalPayment = Convert.ToDecimal(reader["TOTAL_PAYMENT"])
                                };
                            }
                        }

                    }
                    catch (Exception ex) { throw ex; }
                    finally
                    {
                        connection.Close();
                    }
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
            }

            return home;
        }
        public static bool FindHouseUser(string username)
        {
            bool found = false;
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand(@"SELECT COUNT(*) FROM TBL_HOUSELOAN WHERE (FK_USERNAME = @username)", connection);

                        command.Parameters.AddWithValue("@username", username);
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            found = true;
                        }
                    }
                    catch (Exception ex) { throw ex; }
                    finally
                    {
                        connection.Close();
                    }

                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connection.Close();
                }


            }
            return found;
        }
        public static decimal GetHouseAmount(string username)
        {
            decimal cost = 0;
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand(@"SELECT TOTAL_PAYMENT FROM TBL_HOUSELOAN WHERE (FK_USERNAME = @username)", connection);

                        command.Parameters.AddWithValue("@username", username);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                cost = Convert.ToDecimal(reader["TOTAL_PAYMENT"]);
                            }
                        }
                    }
                    catch (Exception ex) { throw ex; }
                    finally
                    {
                        connection.Close();
                    }

                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connection.Close();
                }


            }
            return cost;
        }
    }
}