using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_Practica01_.Domain;
using proyecto_Practica01_.Data.utils;

namespace proyecto_Practica01_.Data
{
    public class ArticuloRepositoryADO: IArticulo
    {
        private SqlConnection _connection;

        public ArticuloRepositoryADO()
        {
            _connection = new SqlConnection(Properties.Resources.cadena);
        }


        public bool Delete(int id)
        {
            var parametros = new List<Parametro>();
            parametros.Add(new Parametro("@id", id));
            int filas = DataHelper.GetInstancia().ExecuteSPNonQuery("sp_borrar_articulo", parametros);
            return filas == 1;
        }

        public List<Articulo> GetAll()
        {
            List<Articulo> lst = new List<Articulo>();
            var helper = DataHelper.GetInstancia();
            var t = helper.ExecuteSP("sp_recuperar_articulos", null);
            foreach (DataRow row in t.Rows)
            {
                //int NroArticulo = Convert.ToInt32(row["nro_articulo"]);
                string nombre = row["nombre"].ToString();
                int precio = Convert.ToInt32(row["precio_unitario"]);


                Articulo oArticulo = new Articulo(nombre, precio);

                lst.Add(oArticulo);
            }
            return lst;
        }

        public Articulo GetById(int id)
        {
            var parametros = new List<Parametro>();
            parametros.Add(new Parametro("@id", id));
            DataTable t = DataHelper.GetInstancia().ExecuteSP("sp_recuperar_articulo", parametros);

            if (t != null && t.Rows.Count == 1)
            {
                DataRow row = t.Rows[0];
                string nombre = row["nombre"].ToString();
                int precio = Convert.ToInt32(row["precio_unitario"]);


                Articulo oArticulo = new Articulo(nombre, precio);


                return oArticulo;

            }
            return null;
        }

        public bool Save(Articulo oArticulo)
        {
            bool result = true;
            string query = "sp_guardar_articulo";

            try
            {
                if (oArticulo != null)
                {
                    _connection.Open();
                    var cmd = new SqlCommand(query, _connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", oArticulo.Nombre);
                    cmd.Parameters.AddWithValue("@precio", oArticulo.PrecioUnitario);
                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException sqlEx)
            {
                result = false;
            }
            finally
            {
                if (_connection != null && _connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return result;
        }
    }
}
