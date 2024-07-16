using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckCaseStatement
{

    public class clsCommand
    {

        private static string connectionString = "Server=.;Database=C21_DB1;User" +
                   " Id=sa;Password=sa123456;";

        public static string ConnectionString()
        {
            return connectionString;
        }

    }
    internal class Program
    {

        static bool UpdateEmployee(string EmployeeName, decimal salary)
        {

            SqlConnection con = new SqlConnection(clsCommand.ConnectionString());
            string query = "UPDATE Employees2 SET Salary = @salary WHERE Name = @EmployeeName";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmd.Parameters.AddWithValue("@salary", salary);
            int rows = 0;
            try
            {
                con.Open();
                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return rows > 0;
        }

        static DataTable EmployeesData()
        {
            SqlConnection con = new SqlConnection(clsCommand.ConnectionString());
            string query = "SELECT * FROM Employees2 ";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dataTable = new DataTable();
            try
            {
                con.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                    dataTable.Load(sqlDataReader);
            }
            catch { }
            finally { con.Close(); }
            return dataTable;
        }
        static void Main(string[] args)
        {

            bool value = UpdateEmployee("Employee 1", 100);
            if (value)
            {
                Console.WriteLine(value.ToString());

            }
            else
            {
                Console.WriteLine(value.ToString());
            }

            DataTable data = EmployeesData();
            foreach (DataRow row in data.Rows)
            {
                if ((int)row[2] > 100)
                {
                    decimal salary = Convert.ToDecimal(row[2]);
                    UpdateEmployee(row[1].ToString(), salary);
                }
                else if((int)row[2] > 1000)
                {

                }
                else
                {

                }
                Console.WriteLine($"Name  : {row[0]}, Salary {row[2]}");
            }
            Console.ReadKey();
        }
    }
}