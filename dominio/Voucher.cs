using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Voucher
    {
        public string codigoVoucher { get; set; }
        public int idCliente { get; set; }
        public DateTime FechaCanje { get; set; }
        public int IdArticulo { get; set; }
    }
}
