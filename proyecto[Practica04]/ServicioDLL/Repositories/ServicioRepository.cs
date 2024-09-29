using ServicioDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDLL.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private DbServiciosContext _context;
        public ServicioRepository(DbServiciosContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var service = GetById(id);
            _context.TServicios.Remove(service);
            return _context.SaveChanges() == 1;
        }

        public List<TServicio> GetAll()
        {
            return _context.TServicios.ToList();
        }

        public TServicio GetById(int id)
        {
            return _context.TServicios.Find(id);
        }

        public List<TServicio> GetPromocion()
        {
            
            return _context.TServicios.Where(x => x.EnPromocion=="S" ).ToList();
        }

        public List<TServicio> GetSinPromocionCosto(float precio)
        {
            return _context.TServicios.Where(x => x.EnPromocion=="N"
            && x.Costo < precio).ToList();
        }

        public bool Save(TServicio oServicio)
        {
            _context.TServicios.Add(oServicio);
            return _context.SaveChanges() == 1;
        }

        public bool Update(TServicio oServicio, int id)
        {
            var found = GetById(id);
            if (found != null)
            { 
                found.Nombre = oServicio.Nombre;
                found.EnPromocion= oServicio.EnPromocion;
                found.Costo = oServicio.Costo;
                _context.TServicios.Update(found);
            }
                return _context.SaveChanges()==1;
        }
    }
}
