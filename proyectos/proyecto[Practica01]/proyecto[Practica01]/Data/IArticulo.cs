using proyecto_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Data
{
    public interface IArticulo
    {
        List<Articulo> GetAll();
        Articulo GetById(int id);
        bool Delete(int id);
        bool Save(Articulo oFactura);
    }
}
