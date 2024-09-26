using ArticulosLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosLibrary.Services
{
    public interface IFacturaService
    {
        List<Factura> GetAllFcaturas();
        Factura GetFactura(int id);
        bool UpdateFactura(Factura oFactura, int id);
        
        bool InsertFcatura(Factura oFactura);

       
    }
}
