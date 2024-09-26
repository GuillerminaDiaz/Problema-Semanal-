using ArticulosLibrary.Data;
using ArticulosLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosLibrary.Services
{
    public class FacturaService : IFacturaService
    {
        private IFacturaRepository _repository;
        public FacturaService()
        {
            _repository = new FacturaRepository();
        }
        public List<Factura> GetAllFcaturas()
        {
            return _repository.GetAll();
        }

        public Factura GetFactura(int id)
        {
            return _repository.GetById(id);
        }

        public bool InsertFcatura(Factura oFactura)
        {
            return _repository.CreateFactura(oFactura);
        }

        public bool UpdateFactura(Factura oFactura, int id)
        {
            return _repository.UpdateFactura(oFactura, id);
        }
    }
}
