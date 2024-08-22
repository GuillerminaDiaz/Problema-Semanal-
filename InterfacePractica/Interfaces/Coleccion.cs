using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractica.Interfaces
{
    public abstract class Coleccion : IColeccion
    {
        protected Object[] array;
        protected int size;
        protected int next;
        public Coleccion(int size)
        {

            this.array = new object[size];
            next = -1;

        }
        public virtual bool añadir(object obj)
        {
            if(next < array.Length)
            {
                array[++next] = obj;
                return true;
            }
            
            return false;   
        }

        public virtual bool estaVacia()
        {
            return next == -1;
        }

        public abstract object extraer();

        public virtual object primero()
        {
            Object primero = null;

            if (!estaVacia()) primero= array[0];

            return primero;
        }
    }
}
