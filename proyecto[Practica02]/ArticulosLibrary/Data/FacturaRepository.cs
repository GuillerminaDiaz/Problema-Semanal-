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
    public class FacturaRepository : IFacturaRepository
    {
        public bool CreateFactura(Factura oFactura)
        {
            bool result = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;
            try
            {
                cnn = DbHelper.GetInstancia().GetConnection();
                cnn.Open();
                t=cnn.BeginTransaction();

                var cmd = new SqlCommand("sp_insertar_factura", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fecha", oFactura.Fecha);
                cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);
                cmd.Parameters.AddWithValue("@formaPago", oFactura.FormaPago);

                SqlParameter param = new SqlParameter("id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int facturaId = (int)param.Value;

                foreach (var detalle in oFactura.detalleFacturas)
                {
                    var cmdDetalle = new SqlCommand("sp_insertar_detalle", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@articulo", detalle.Articulo);
                    cmdDetalle.Parameters.AddWithValue("@factura", facturaId);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                }

                t.Commit();
            }
            catch (Exception)
            {

                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }

        public List<Factura> GetAll()
        {
            List<Factura> list= new List<Factura>();
            Factura? oFactura = null;
            var t = DbHelper.GetInstancia().Consultar("sp_get_all_facturas");

            foreach(DataRow r in t.Rows)
            {
                if(oFactura == null || oFactura.NroFactura != (int)r["nro_factura"])
                {
                    oFactura= new Factura();
                    oFactura.NroFactura = (int)r["nro_factura"];
                    oFactura.Fecha = (DateTime)r["fecha"];
                    oFactura.Cliente = r["cliente"].ToString();
                    oFactura.FormaPago = new FormaPago
                    {
                        idFormaPago = (int)r["forma_pago"]  
                    };
                    oFactura.AddDetail(ReadDetalle(r));
                    list.Add(oFactura);

                }
                else
                {
                    oFactura.AddDetail(ReadDetalle(r));
                }
            }
                return list;
        }

        private DetalleFactura ReadDetalle(DataRow r)
        {
            DetalleFactura detalle = new DetalleFactura
            {
                NroDetalle = (int)r["nro_detalle"],
                Articulo = new Articulo()
                {
                    NroArticulo = (int)r["nro_articulo"],
                    Nombre = r["nombre"].ToString(),
                    PrecioUnitario= (float)r["precio_unitario"]
                },
                Cantidad = (int)r["cantidad"],
             };
            return detalle;
            
        }

        public Factura GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFactura(Factura oFactura, int id)
        {
            bool result = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;
            try
            {
                cnn = DbHelper.GetInstancia().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("sp_modificar_factura", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fecha", oFactura.Fecha);
                cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);
                cmd.Parameters.AddWithValue("@formaPago", oFactura.FormaPago);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            
                foreach (var detalle in oFactura.detalleFacturas)
                {
                    var cmdDetalle = new SqlCommand("sp_insertar_detalle", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@articulo", detalle.Articulo);
                    cmdDetalle.Parameters.AddWithValue("@factura", id);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                }

                t.Commit();
            }
            catch (Exception)
            {

                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }
    }
}
