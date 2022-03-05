using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;
using System.Web.Configuration;

namespace Arena.MyPlan
{
    public class DataHelper
    {
        public DataHelper()
        {
        }

        public static int GetHelpId(int clientId)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Arena"].ConnectionString);
            SqlCommand cmd = new SqlCommand("cust_sp_salc_mp_gethelpid_client", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int ret = -1;
            while (reader.Read())
            {
                ret = reader.GetInt32(0);
            }

            return ret;
        }
    }
}
