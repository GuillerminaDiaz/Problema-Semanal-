using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractica.Productos
{
    public class Pack : Producto
    {
        private int Cantidad {  get; set; }
        public Pack(int cantidad, int Codigo, string Nombre, float Precio): base(Codigo, Nombre, Precio) 
        {

            this.Cantidad = cantidad;

        }

        public override float CalcularPrecio()
        {
            float precio = Cantidad * base.Precio;
            return precio;
        }
    }
}
