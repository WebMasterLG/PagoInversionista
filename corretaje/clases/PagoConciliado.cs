using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace corretaje.clases
{
    public class PagoConciliado
    {
        public Int64 boleta { get; set; }
        public int idContrato { get; set; }
        public string concepto { get; set; }
        public int monto { get; set; }
        public string medio_pago { get; set; }
        public string estado { get; set; }
    }
}