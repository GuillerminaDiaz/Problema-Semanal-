using proyecto_Practica01_.Data.utils;
using proyecto_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Data
{
    public class FormaPagoRepositoryADO : IFormaPago
    {
        public bool Create(FormaPago oFormaPago)
        {
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@nombre", oFormaPago.Nombre));
            int filas = DataHelper.GetInstancia().ExecuteSPNonQuery("sp_crear_forma_pago", lst);
            return filas == 1;
        }
    }
}
