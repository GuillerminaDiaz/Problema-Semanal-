using proyecto_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Data
{
    public interface IFacturaRepository
    {
        List<Factura> GetAll();
        Factura GetById(int id);
      
        bool Save(Factura oFactura, string nombreFormaPago);
    }
}
