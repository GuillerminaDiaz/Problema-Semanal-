using proyecto_Practica01_.Data.utils;
using proyecto_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Data
{
    public class FacturaRepositoryADO : IFacturaRepository
    {
        private DetalleFactura LeerDetalle(DataRow fila)
        {
            DetalleFactura detalle= new DetalleFactura();
            detalle.Articulo = new Articulo
            {
                NroArticulo = (int)fila["nro_articulo"],
                Nombre = fila["nombre"].ToString(),
                PrecioUnitario= (float)fila["precio_unitario"]
            };
            detalle.Cantidad = (int)fila["cantidad"];
            return detalle;
        }
       

        public List<Factura> GetAll()
        {
            List<Factura> lst= new List<Factura>();
            Factura? oFactura = null;
            var helper = DataHelper.GetInstancia();
            var t = helper.ExecuteSP("sp_recuperar_facturas", null);

            foreach (DataRow row in t.Rows)
            {
                if (oFactura != null || oFactura.NroFactura != Convert.ToUInt32(row["nro_factura"].ToString()))
                {
                    oFactura= new Factura();
                    oFactura.NroFactura = (int)row["nro_factura"];
                    oFactura.Fecha = (DateTime)row["fecha"];
                    oFactura.Cliente = row["cliente"].ToString();
                    FormaPago formaPago= new FormaPago();
                    oFactura.FormaPago = formaPago;
                    oFactura.AddDetail(LeerDetalle(row));
                    lst.Add(oFactura);
                }
                else 
                {
                    oFactura.AddDetail(LeerDetalle(row));
                }
            }
            return lst;
          
        }

        public Factura GetById(int id)
        {
            Factura? oFactura = null;
            var helper = DataHelper.GetInstancia();
            var parametro = new Parametro("@id", id);
            var lstParametros= new List<Parametro>();
            lstParametros.Add(parametro);

            var t = helper.ExecuteSP("sp_recuperar_factura_id", null);
            foreach (DataRow row in t.Rows)
            {
                if (oFactura != null || oFactura.NroFactura != Convert.ToUInt32(row["nro_factura"].ToString()))
                {
                    oFactura = new Factura();
                    oFactura.NroFactura = (int)row["nro_factura"];
                    oFactura.Fecha = (DateTime)row["fecha"];
                    oFactura.Cliente = row["cliente"].ToString();
                    FormaPago formaPago = new FormaPago();
                    oFactura.FormaPago = formaPago;
                    oFactura.AddDetail(LeerDetalle(row));
                    
                }
                else
                {
                    oFactura.AddDetail(LeerDetalle(row));
                }
            }
            return oFactura;
        }

        public bool Save(Factura oFactura, string nombreFormaPago)
        {
            bool resultado = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;

            try
            {
                cnn = DataHelper.GetInstancia().GetConnection();
                cnn.Open();
                t= cnn.BeginTransaction();

                //var command = new SqlCommand("sp_crear_forma_pago", cnn, t);
                //command.CommandType = System.Data.CommandType.StoredProcedure;

                //command.Parameters.AddWithValue("nombre", nombreFormaPago);

                //SqlParameter parametro = new SqlParameter("@id", SqlDbType.Int);
                //parametro.Direction = ParameterDirection.Output;
                //command.Parameters.Add(parametro);
                //command.ExecuteNonQuery();

                //int formaPagoId = (int)parametro.Value;

                var commandFactura = new SqlCommand("sp_insertar_factura", cnn, t);
                commandFactura.CommandType = System.Data.CommandType.StoredProcedure;

                commandFactura.Parameters.AddWithValue("fecha", oFactura.Fecha);
                commandFactura.Parameters.AddWithValue("cliente", oFactura.Cliente);
                commandFactura.Parameters.AddWithValue("formaPago", oFactura.FormaPago.idFormaPago);

                SqlParameter parametroFactura = new SqlParameter("@id", SqlDbType.Int);
                parametroFactura.Direction = ParameterDirection.Output;
                commandFactura.Parameters.Add(parametroFactura);
                commandFactura.ExecuteNonQuery();

                int facturaId = (int)parametroFactura.Value;

                foreach (var detalle in oFactura.GetDetalles())
                {
                    var commandDetalle = new SqlCommand("sp_insertar_detalle", cnn, t);
                    commandDetalle.CommandType= CommandType.StoredProcedure;

                    commandDetalle.Parameters.AddWithValue("@articulo", detalle.Articulo.NroArticulo );
                    commandDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    commandDetalle.Parameters.AddWithValue("@factura", facturaId);
                    commandDetalle.ExecuteNonQuery();
                }

                t.Commit();
            }
            catch(SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                resultado = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return resultado;
        }
    }
}
