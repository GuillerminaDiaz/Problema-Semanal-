using InterfacePractica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractica.Clases
{
    public class Cola : Coleccion
    {
        public Cola(int size): base(size)
        {
            
        }
        public override object extraer()
        {
            object o = null;
            if (!estaVacia())
            {
                o = array[0];
                                
                for (int i = 1; i <= next; i++)
                {
                    array[i - 1] = array[i];
                }
                                
                array[next] = null;
                             
                next--;
            }
            return o;
        }
        
       
    }
}
