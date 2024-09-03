using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractica.Productos
{
    public class Suelto : Producto
    {
        private float Medida {  get; set; }

        public Suelto(float medida, int Codigo, string Nombre, float Precio) : base(Codigo, Nombre, Precio)
        {
            this.Medida = medida;
        }

        public override float CalcularPrecio()
        {
            float precio= Medida * Precio;
            return precio;
        }
    }
}
