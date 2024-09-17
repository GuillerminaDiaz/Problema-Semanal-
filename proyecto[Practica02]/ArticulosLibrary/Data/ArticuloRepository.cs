using ArticulosLibrary.Data.Utils;
using ArticulosLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosLibrary.Data
{
    public class ArticuloRepository : IArticuloRepository
    {
        public bool DeleteArticulo(int id)
        {
            var lstParams= new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@id", id));

            int filas = DbHelper.GetInstancia().ConsultarNonQuery("sp_borrar_articulo", lstParams);
            return filas == 1;
        }

        public List<Articulo> GetAllArticulos()
        {
            DataTable tabla = DbHelper.GetInstancia().Consultar("sp_recuperar_articulos");
            List<Articulo> lst = new List<Articulo>();

            foreach(DataRow row in tabla.Rows)
            {
                int nro = (int)row["nro_articulo"];
                string nombre = row["nombre"].ToString();
                float precio = float.Parse(row["precio_unitario"].ToString());

                var articulo= new Articulo()
                {
                    NroArticulo= nro,
                    Nombre= nombre,
                    PrecioUnitario= precio
                };

                lst.Add(articulo);
            }
            return lst;
        }

        public Articulo GetArticulo(int id)
        {
            var lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@id", id));

            DataTable tabla = DbHelper.GetInstancia().Consultar("sp_recuperar_articulo", lstParams);

            DataRow row= tabla.Rows[0];
            int nro = (int)row["nro_articulo"];
            string nombre = row["nombre"].ToString();
            float precio = float.Parse(row["precio_unitario"].ToString());

            var articulo = new Articulo()
            {
                NroArticulo = nro,
                Nombre = nombre,
                PrecioUnitario = precio
            };

            return articulo;
        }

        public bool InsertArticulo(Articulo oArticulo)
        {
            
            var lstParams= new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@nombre", oArticulo.Nombre));
            lstParams.Add(new SqlParameter("@precio", oArticulo.PrecioUnitario));

            int filas = DbHelper.GetInstancia().ConsultarNonQuery("sp_guardar_articulo", lstParams);
            return filas == 1;
        }

        public bool UpdateArticulo(Articulo oArticulo, int id)
        {   
            var lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@id", id));

            if(oArticulo.Nombre != "string" && oArticulo.PrecioUnitario != 0)
            {
                lstParams.Add(new SqlParameter("@nombre", oArticulo.Nombre));
                lstParams.Add(new SqlParameter("@precio", oArticulo.PrecioUnitario));
            }
            else if (oArticulo.Nombre == "string" && oArticulo.PrecioUnitario != 0)
            {
                lstParams.Add(new SqlParameter("@precio", oArticulo.PrecioUnitario));
            }
            else if(oArticulo.PrecioUnitario == 0 && oArticulo.Nombre != "string")
            {
                lstParams.Add(new SqlParameter("@nombre", oArticulo.Nombre));
            }


            int filas = DbHelper.GetInstancia().ConsultarNonQuery("sp_modificar_articulo", lstParams);
            return filas == 1;
        }
    }
}
