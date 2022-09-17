using System;
using System.Data.SqlClient;

namespace Data
{
    public class Conexion
    {
        protected SqlConnection ObjCn { get; }

        public Conexion() {
            String conexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BD_MARIO_ROBLES;User Id=utest;Password=abcd1234.";
            ObjCn = new SqlConnection(conexion);
        }
    }
}
