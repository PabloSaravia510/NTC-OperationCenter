using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data.SqlServer
{
    public class Conexion
    {
        public SqlConnection ConectarBD()
        {
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
            return cn;
        }
    }
}
