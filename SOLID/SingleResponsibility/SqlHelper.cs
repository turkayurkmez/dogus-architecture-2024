using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SingleResponsibility
{
    public class SqlHelper
    {
        string connectionString = string.Empty;

        public SqlHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int ExecuteNonQuery(string commandText, Dictionary<string,object> parameters)
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.Parameters.AddWithValue("@name", name);
            //sqlCommand.Parameters.AddWithValue("@price", price);
            //elbette parameters içinde dönerek, her bir parametreyi ekleyecek....
            sqlConnection.Open();
            var affectedCount = 1;
           // var affectedCount = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return affectedCount;
        }
    }
}
