using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Data.utils
{
    public class DataHelper
    {
        private static DataHelper _instancia;
        private SqlConnection _connection;
        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.cadena);
        }

        public static DataHelper GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new DataHelper();
            }
            return _instancia;
        }

        public DataTable ExecuteSP(string sp, List<Parametro>? lstParametros)
        {
            DataTable dt = new DataTable();
            try
            {
                _connection.Open();
                var command = new SqlCommand(sp, _connection);
                command.CommandType = CommandType.StoredProcedure;
                if (lstParametros != null)
                {
                    foreach (Parametro p in lstParametros)
                    {
                        command.Parameters.AddWithValue(p.Nombre, p.Valor);
                    }

                }
                
                dt.Load(command.ExecuteReader());
                _connection.Close();
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }
        public int ExecuteSPNonQuery(string sp, List<Parametro>? lstParametros)
        {
            int filasAfectadas = 0;
            try
            {
                _connection.Open();
                var command = new SqlCommand(sp, _connection);
                command.CommandType = CommandType.StoredProcedure;
                if (lstParametros != null)
                {
                    foreach (Parametro p in lstParametros)
                    {
                        command.Parameters.AddWithValue(p.Nombre, p.Valor);
                    }
                }
                filasAfectadas = command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception)
            {
                filasAfectadas = 0;
            }
            return filasAfectadas;
        }

        public SqlConnection GetConnection()
        {
            
            return _connection;
        }

    }
}
