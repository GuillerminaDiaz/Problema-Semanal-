using ArticulosLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosLibrary.Data
{
    public interface IFacturaRepository
    {
        bool CreateFactura(Factura oFactura);
        List<Factura> GetAll();
        Factura GetById(int id);
        bool UpdateFactura(Factura oFactura, int id);
    }
}
