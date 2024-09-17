using ArticulosLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosLibrary.Data
{
    public interface IArticuloRepository
    {
        List<Articulo> GetAllArticulos();
        Articulo GetArticulo(int id);
        bool UpdateArticulo(Articulo oArticulo, int id);
        bool DeleteArticulo(int id);
        bool InsertArticulo(Articulo oArticulo);

    }
}
