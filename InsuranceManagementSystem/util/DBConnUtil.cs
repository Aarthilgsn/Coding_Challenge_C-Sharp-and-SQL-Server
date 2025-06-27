using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace InsuranceManagementSystem.util
{
   
        public class DBConnUtil
        {
            private static SqlConnection connection;

            public static SqlConnection GetConnection()
            {
                if (connection == null || connection.State == System.Data.ConnectionState.Closed)
                {
                    try
                    {
                        string filePath = "appsettings.properties"; // make sure this file is in output directory
                        string connectionString = DBPropertyUtil.GetConnectionString(filePath);

                        if (string.IsNullOrEmpty(connectionString))
                        {
                            Console.WriteLine("Invalid or missing connection string.");
                            return null;
                        }

                        connection = new SqlConnection(connectionString);
                        connection.Open();
                        Console.WriteLine("Database connection established.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error establishing database connection: " + ex.Message);
                    }
                }

                return connection;
            }
        }
    }


