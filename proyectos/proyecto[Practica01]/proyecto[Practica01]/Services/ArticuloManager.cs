using proyecto_Practica01_.Data;
using proyecto_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Services
{
    public class ArticuloManager
    {
        private IArticulo _repositorio;
        public ArticuloManager()
        {
            _repositorio= new ArticuloRepositoryADO();
        }

        public List<Articulo> GetArticulos()
        {
            return _repositorio.GetAll();
        }

        public Articulo GetArticuloById(int id)
        {
            return _repositorio.GetById(id);
        }

        public bool SaveArticulo(Articulo oArticulo)
        {
            return _repositorio.Save(oArticulo);
        }
        public bool DeleteArticulo(int id)
        {
            return _repositorio.Delete(id);
        }
    }
}
