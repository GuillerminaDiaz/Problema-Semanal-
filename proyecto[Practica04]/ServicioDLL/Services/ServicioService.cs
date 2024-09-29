using ServicioDLL.Models;
using ServicioDLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDLL.Services
{
    public class ServicioService : IServicioService
    {
        private IServicioRepository _repository;
        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<TServicio> GetAll()
        {
            return _repository.GetAll();
        }

        public TServicio GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<TServicio> GetPromocion()
        {
            return _repository.GetPromocion();
        }

        public List<TServicio> GetSinPromocionCosto(float precio)
        {
            return _repository.GetSinPromocionCosto(precio);
        }

        public bool Save(TServicio oServicio)
        {
            return _repository.Save(oServicio);
        }

        public bool Update(TServicio oServicio, int id)
        {
            return _repository.Update(oServicio, id);
        }
    }
}
