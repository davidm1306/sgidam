using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgidam.Models
{
    public class Lote
    {
        public int IdLote { get; set; }
        public int IdProducto { get; set; }
        public int IdDetalleCompra { get; set; }
        public string CodigoLote { get; set; }
        public int CantidadInicial { get; set; }
        public int CantidadDisponible { get; set; }
        public decimal CostoUnitario { get; set; }
        public DateTime FechaEntrada { get; set; }
        public int? Estatus { get; set; }
    }
}
