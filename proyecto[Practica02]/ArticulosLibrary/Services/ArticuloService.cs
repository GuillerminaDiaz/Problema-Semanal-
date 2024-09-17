using ArticulosLibrary.Data;
using ArticulosLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosLibrary.Services
{
    public class ArticuloService : IArticuloService
    {
        private IArticuloRepository repository;
        public ArticuloService()
        {
            repository= new ArticuloRepository();
        }
        public bool DeleteArticulo(int id)
        {
            return repository.DeleteArticulo(id);
        }

        public List<Articulo> GetAllArticulos()
        {
            return repository.GetAllArticulos();
        }

        public Articulo GetArticulo(int id)
        {
            return repository.GetArticulo(id);
        }

        public bool InsertArticulo(Articulo oArticulo)
        {
            return repository.InsertArticulo(oArticulo);
        }

        public bool UpdateArticulo(Articulo oArticulo, int id)
        {
            return repository.UpdateArticulo(oArticulo, id);
        }
    }
}
