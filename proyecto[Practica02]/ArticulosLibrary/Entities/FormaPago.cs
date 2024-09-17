using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticulosLibrary.Entities
{
    public class FormaPago
    {
        public int idFormaPago { get; set; }
        public string Nombre { get; set; }
        public FormaPago()
        {

        }
        public FormaPago(string nombre)
        {
            Nombre = nombre;
        }
    }
}
