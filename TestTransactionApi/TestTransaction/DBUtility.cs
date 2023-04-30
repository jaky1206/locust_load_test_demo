using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestTransaction
{
    public class DBUtility
    {
        private static string _mConString;
        public static string ConnectionString
        {

            set
            {
                _mConString = value;
            }
            get
            {
                return _mConString;
            }
        }

        public static void InsertTable(string transId, double amount, string clientRequestTime)
        {
            try
            {
                //string createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                string query = "INSERT INTO Transactions (TransactionId, Amount, RequestTime, CreateTime) VALUES('" + transId + "', " + amount + ", '" + clientRequestTime + "', GETDATE());";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}
