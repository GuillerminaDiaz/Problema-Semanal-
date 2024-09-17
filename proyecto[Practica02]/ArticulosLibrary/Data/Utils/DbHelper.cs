using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosLibrary.Data.Utils
{
    public class DbHelper
    {
        private static DbHelper instancia = null;
        private SqlConnection conexion;

        private DbHelper()
        {
            conexion = new SqlConnection(@"Data Source=LAPTOP-9E07VAI3\SQLEXPRESS;Initial Catalog=Facturacion;Integrated Security=True");
        }

        public static DbHelper GetInstancia()
        {
            if (instancia == null)
                instancia = new DbHelper();
            return instancia;
        }

        public SqlConnection GetConnection()
        {
            return conexion;
        }


        public DataTable Consultar(string nombreSP, List<SqlParameter>? parameters = null)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;

            if (parameters != null)
            {
                foreach (var param in parameters)
                    comando.Parameters.AddWithValue(param.ParameterName, param.Value);
            }

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }
        public int ConsultarNonQuery(string nombreSP, List<SqlParameter>? parameters = null)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;

            if (parameters != null)
            {
                foreach (var param in parameters)
                    comando.Parameters.AddWithValue(param.ParameterName, param.Value);
            }

            int filasAfectadas = comando.ExecuteNonQuery();
            
            conexion.Close();
            return filasAfectadas;
        }
    }

}
