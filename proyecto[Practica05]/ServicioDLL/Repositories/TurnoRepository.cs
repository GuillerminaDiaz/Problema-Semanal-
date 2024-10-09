using ServicioDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDLL.Repositories
{
    public class TurnoRepository : ITurnoRepository
    {
        private DbServiciosContext _context;
        public TurnoRepository(DbServiciosContext context)
        {
            _context = context;
        }
        public bool CreateTurno(TTurno turno)
        {
            _context.Add(turno);

            return _context.SaveChanges() == 1;
        }

        public bool DeleteTurno(int id)
        {
            var found= _context.TTurnos.Find(id);
            if (found != null)
            {
                _context.TTurnos.Remove(found);
            }
            return _context.SaveChanges() == 1;
        }

        public List<TTurno> GetAllTurno()
        {
            return _context.TTurnos.ToList();
        }

        public bool UpdateTurno(int id, TTurno turno)
        {
            var found = _context.TTurnos.Find(id);
            if (found != null)
            {
                found.Hora= turno.Hora;
                found.Fecha= turno.Fecha;
                found.Cliente= turno.Cliente;
            }
            return _context.SaveChanges() == 1;
        }
    }
}
