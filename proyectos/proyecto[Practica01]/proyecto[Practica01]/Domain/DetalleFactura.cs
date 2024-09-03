using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Domain
{
    public class DetalleFactura
    {
        public int NroDetalle {  get; set; }
        public int Cantidad { get; set; }
        public Articulo Articulo { get; set; }
       
        public DetalleFactura()
        {
            
        }
        //public DetalleFactura(int cantidad, Factura factura, Articulo articulo)
        //{
        //    Cantidad = cantidad;

        //    Articulo = articulo;
        //}
        public float SubTotal()
        {
            return Cantidad * Articulo.PrecioUnitario;
        }

    }
}
