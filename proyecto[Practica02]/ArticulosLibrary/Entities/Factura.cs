using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosLibrary.Entities
{
    public class Factura
    {
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago FormaPago { get; set; }
        public string Cliente { get; set; }
        public List<DetalleFactura> detalleFacturas { get; set; }
        public Factura()
        {
            detalleFacturas = new List<DetalleFactura>();
        }

        public void AddDetail(DetalleFactura detalle)
        {
            if (detalle != null)
            {
                detalleFacturas.Add(detalle);
            }
        }

        public void Remove(int index)
        {
            detalleFacturas.RemoveAt(index);
        }

        public float Total()
        {
            float total = 0;
            foreach (DetalleFactura detalle in detalleFacturas)
            {
                total += detalle.SubTotal();
            }
            return total;
        }

        public List<DetalleFactura> GetDetalles()
        {
            return detalleFacturas;
        }
    }
}
