using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BudgetWebApp.Classes
{
    public class VehicleDb
    {
        public static void AddVehicle(string name, Vehicle vehicle)
        {
            int months = 60;
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("INSERT INTO TBL_VEHICLE_LOAN(FK_USERNAME,MODEL,MAKE,VEHICLE_PURCHASE_PRICE,VEHICLE_DEPOSIT," +
                            "VEHICLE_INTEREST,INSURANCE,VEHICLE_MONTHS_TO_PAY,VEHICLE_MONTHLY_PAYMENT,VEHICLE_TOTAL_PAYMENT) " +
                            "VALUES (@FK_USERNAME,@MODEL,@MAKE,@VEHICLE_PURCHASE_PRICE,@VEHICLE_DEPOSIT,@VEHICLE_INTEREST," +
                            "@INSURANCE,@VEHICLE_MONTHS_TO_PAY,@VEHICLE_MONTHLY_PAYMENT,@VEHICLE_TOTAL_PAYMENT)", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);
                        command.Parameters.AddWithValue("@MODEL", vehicle.Model);
                        command.Parameters.AddWithValue("@MAKE", vehicle.Make);
                        command.Parameters.AddWithValue("@VEHICLE_PURCHASE_PRICE", vehicle.PurchasePrice);
                        command.Parameters.AddWithValue("@VEHICLE_DEPOSIT", vehicle.TotalDeposit);
                        command.Parameters.AddWithValue("@VEHICLE_INTEREST", vehicle.InterestRate);
                        command.Parameters.AddWithValue("@INSURANCE", vehicle.Insurance);
                        command.Parameters.AddWithValue("@VEHICLE_MONTHS_TO_PAY", months);
                        command.Parameters.AddWithValue("@VEHICLE_MONTHLY_PAYMENT", vehicle.VehicleMonthlyPayment);
                        command.Parameters.AddWithValue("@VEHICLE_TOTAL_PAYMENT", vehicle.TotalVehiclePayment);

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
        public static bool FindVehicleUser(string username)
        {
            bool found = false;
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand(@"SELECT COUNT(*) FROM TBL_VEHICLE_LOAN WHERE (FK_USERNAME = @username)", connection);

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
        public static Vehicle GetVehicleLoan(string name)
        {
            Vehicle vehicle = new Vehicle();
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("SELECT MODEL,MAKE,VEHICLE_PURCHASE_PRICE,VEHICLE_DEPOSIT,VEHICLE_INTEREST," +
                                                     "INSURANCE,VEHICLE_MONTHS_TO_PAY,VEHICLE_MONTHLY_PAYMENT,VEHICLE_TOTAL_PAYMENT " +
                                                     "FROM TBL_VEHICLE_LOAN  WHERE (FK_USERNAME=@FK_USERNAME)", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                vehicle = new Vehicle
                                {
                                    Model = reader["MODEL"].ToString(),
                                    Make = reader["MAKE"].ToString(),
                                    PurchasePrice  = Convert.ToDecimal(reader["VEHICLE_PURCHASE_PRICE"]),
                                    TotalDeposit = Convert.ToDecimal(reader["VEHICLE_DEPOSIT"]),
                                    InterestRate = Convert.ToDecimal(reader["VEHICLE_INTEREST"]),
                                    Insurance = Convert.ToDecimal(reader["INSURANCE"]),
                                    MONTHSTOPAY = Convert.ToInt32(reader["VEHICLE_MONTHS_TO_PAY"]),
                                    VehicleMonthlyPayment = Convert.ToDecimal(reader["VEHICLE_MONTHLY_PAYMENT"]),
                                    TotalVehiclePayment = Convert.ToDecimal(reader["VEHICLE_TOTAL_PAYMENT"])
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

            return vehicle;
        }
    }
}