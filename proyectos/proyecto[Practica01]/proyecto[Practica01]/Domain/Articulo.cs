using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Domain
{
    public class Articulo
    {
        public int NroArticulo {  get; set; }
        public string Nombre { get; set; }
        public float PrecioUnitario { get; set; }

        public Articulo()
        {
            
        }
        public Articulo(string nombre, float precio)
        {
            Nombre = nombre;
            PrecioUnitario = precio;
            
        }

    }
}
