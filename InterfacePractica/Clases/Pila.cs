using InterfacePractica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractica.Clases
{
    public class Pila : Coleccion
    {
        public Pila(int size):base (size)
        {
            
        }
        public override object extraer()
        {
            object o = null;
            if (!estaVacia())
            {
                
                o = array[next];
                array[next] = null;
                next--;
            }
            return o;
        }
    }
}
