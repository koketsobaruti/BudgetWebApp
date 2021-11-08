using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BudgetWebApp.Classes
{
    public class IncomeExpensesDb
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
                        var command = new SqlCommand("INSERT INTO INCOME_EXPENSES(FK_USERNAME,NET_INCOME,TOTAL_EXPENSES)" +
                                                     " VALUES(@FK_USERNAME,@NET_INCOME,@TOTAL_EXPENSES)", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);
                        command.Parameters.AddWithValue("@NET_INCOME", income.NetIncome);
                        command.Parameters.AddWithValue("@TOTAL_EXPENSES", income.TotalExpenses);

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
        public static void UpdateNewTotal(string username, decimal sum)
        {
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("UPDATE INCOME_EXPENSES SET TOTAL_EXPENSES=(TOTAL_EXPENSES + @sum) WHERE FK_USERNAME = @user");

                        command.Parameters.AddWithValue("@sum", sum);
                        command.Parameters.AddWithValue("@user", username);

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
        public static void UpdateIncome(string name, Income income)
        {
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("UPDATE TBL_USER_INCOME SET (NET_INCOME=@NET_INCOME), " +
                                                     "(TOTAL_EXPENSES=@TOTAL_EXPENSES)  WHERE (FK_USERNAME = @FK_USERNAME)", connection);

                        command.Parameters.AddWithValue("@NET_INCOME", income.NetIncome);
                        command.Parameters.AddWithValue("@TOTAL_EXPENSES", income.TotalExpenses);
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
                        var command = new SqlCommand("SELECT NET_INCOME,TOTAL_EXPENSES FROM TBL_USER_INCOME" +
                                                     " WHERE FK_USERNAME = @FK_USERNAME", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                income = new Income
                                {
                                    NetIncome = Convert.ToDecimal(reader["NET_INCOME"]),
                                    TotalExpenses = Convert.ToDecimal(reader["TOTAL_EXPENSES"])
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
    }
}