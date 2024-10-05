using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Cliente
    {
        public int id { get; set; }
        public string documento { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public int codigoPostal { get; set; }


        public override string ToString()
        {
            return nombre + " " + apellido;
        }


    }
}
