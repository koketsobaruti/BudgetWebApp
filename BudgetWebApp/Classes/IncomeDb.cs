using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BudgetWebApp.Classes
{
    public class IncomeDb
    {
        public static void AddIncome(string name, Income income)
        {
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("INSERT INTO TBL_USER_INCOME(FK_USERNAME,GROSS_INCOME,TAX,INCOME_AFTER_TAX)" +
                                                     " VALUES(@FK_USERNAME,@GROSS_INCOME,@TAX,@INCOME_AFTER_TAX)", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);
                        command.Parameters.AddWithValue("@GROSS_INCOME", income.GrossIncome);
                        command.Parameters.AddWithValue("@TAX", income.Tax);
                        command.Parameters.AddWithValue("@INCOME_AFTER_TAX", income.IncomeAfterTax);

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

        
        public static Income GetIncome(string name)
        {
            Income income = new Income();
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("SELECT GROSS_INCOME,TAX,INCOME_AFTER_TAX FROM TBL_USER_INCOME" +
                                                     " WHERE FK_USERNAME = @FK_USERNAME", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                income = new Income
                                {
                                    GrossIncome = Convert.ToDecimal(reader["GROSS_INCOME"]),
                                    Tax = Convert.ToDecimal(reader["TAX"]),
                                    IncomeAfterTax = Convert.ToDecimal(reader["INCOME_AFTER_TAX"])
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

            return income;
        }
        public static decimal GetTotalExpense(string name)
        {
            decimal total = 0;
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("SELECT INCOME_AFTER_TAX FROM TBL_USER_INCOME  WHERE FK_USERNAME = @FK_USERNAME", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                total = Convert.ToDecimal(reader["INCOME_AFTER_TAX"]);
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

            return total;
        }

        public static decimal GetGrossIncome(string name)
        {
            decimal total = 0;
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("SELECT GROSS_INCOME FROM TBL_USER_INCOME  WHERE FK_USERNAME = @FK_USERNAME", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                total = Convert.ToDecimal(reader["GROSS_INCOME"]);
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

            return total;
        }

        public static void UpdateIncome(string name, Income income)
        {
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("UPDATE TBL_USER_INCOME SET GROSS_INCOME = @GROSS_INCOME, TAX=@TAX , " +
                                                     "INCOME_AFTER_TAX=@INCOME_AFTER_TAX WHERE FK_USERNAME = @FK_USERNAME", connection);

                        command.Parameters.AddWithValue("@GROSS_INCOME", income.GrossIncome);
                        command.Parameters.AddWithValue("@TAX", income.Tax);
                        command.Parameters.AddWithValue("@INCOME_AFTER_TAX", income.IncomeAfterTax);
                        command.Parameters.AddWithValue("@FK_USERNAME", name);

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
        public static bool FindUserIncome(string username)
        {
            bool found = false;
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand(@"SELECT COUNT(*) FROM TBL_USER_INCOME WHERE (FK_USERNAME = @username)", connection);

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
    }
}