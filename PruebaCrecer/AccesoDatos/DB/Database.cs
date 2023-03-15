using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Mysqlx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Models;

namespace AccesoDatos.DB
{
    public class Database
    {
        public String ObtenerConexion()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "local";
            connectionStringBuilder.InitialCatalog = "BDCrecer";
            connectionStringBuilder.IntegratedSecurity = true;
            var cn = connectionStringBuilder.ConnectionString;
            return cn;
        }
    }
}