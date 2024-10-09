using ServicioDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDLL.Repositories
{
    public interface ITurnoRepository
    {
        bool CreateTurno(TTurno turno);
        bool DeleteTurno(int id);
        bool UpdateTurno(int id, TTurno turno);
        List<TTurno> GetAllTurno();
    }
}
