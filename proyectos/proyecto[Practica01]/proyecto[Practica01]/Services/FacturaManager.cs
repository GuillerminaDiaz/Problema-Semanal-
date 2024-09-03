using proyecto_Practica01_.Data;
using proyecto_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Services
{
    public class FacturaManager
    {
        private IFacturaRepository _repositorio;
        public FacturaManager()
        {
            _repositorio = new FacturaRepositoryADO();
        }

        public List<Factura> GetFacturas()
        {
            return _repositorio.GetAll();
        }

        public Factura? GetFacturaById(int id)
        {
            return _repositorio.GetById(id);
        }
    }
}
