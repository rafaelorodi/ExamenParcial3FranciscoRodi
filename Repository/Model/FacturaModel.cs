using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public int Id_cliente { get; set; }
        public string Nro_Factura { get; set; }
        public string Fecha_Hora { get; set; }
        public int Total { get; set; }
        public int Total_iva5 { get; set; }
        public int Total_iva10 { get; set; }
        public int Total_iva { get; set; }
        public string Total_letras { get; set; }
        public string Sucursal { get; set; }
    }
}
