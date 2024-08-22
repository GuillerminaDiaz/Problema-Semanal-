using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractica.Productos
{
    public abstract class Producto : IPrecio
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }

        public Producto(int codigo, string nombre, float precio)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Precio = precio;
        }
        public abstract float CalcularPrecio();
    }
}
