using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models.Connection
{
    public class DbRepository
    {
        public static SqlConnection MsConnection()
        {
            return new SqlConnection(DefaultMsString());
        }

        private static string DefaultMsString()
        {
            return new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-VORHPRK",
                InitialCatalog = "construction",
                UserID = "sa",
                Password = "qwer1234"
            }.ToString();
        }
       
    }


}
