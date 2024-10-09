using ServicioDLL.Models;
using ServicioDLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDLL.Services
{
    public interface IServicioService
    {
        List<TServicio> GetAll();
        TServicio GetById(int id);
        bool Save(TServicio oServicio);
        bool Update(TServicio oServicio, int id);
        bool Delete(int id);

        //obtener los servicios con promoción
        List<TServicio> GetPromocion();

        //obtener servicios sin promocion cuyo costo sea menor al precio indicado
        List<TServicio> GetSinPromocionCosto(float precio);
    }
}
