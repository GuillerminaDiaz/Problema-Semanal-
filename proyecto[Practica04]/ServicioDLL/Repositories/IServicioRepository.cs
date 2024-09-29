using ServicioDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDLL.Repositories
{
    public interface IServicioRepository
    {
        List<TServicio> GetAll();
        TServicio GetById(int id);
        bool Save(TServicio oServicio);
        bool Update(TServicio oServicio, int id);
        bool Delete(int id);
        List<TServicio> GetPromocion();

        List<TServicio> GetSinPromocionCosto(float precio);
    }
}
