using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility
{
    public class ProductService
    {
        public int CreateNewProduct(string name, decimal price)
        {

            var affectedCount = new SqlHelper("cumle").ExecuteNonQuery("sorgu", null);          
            return affectedCount;
        }
    }
}
