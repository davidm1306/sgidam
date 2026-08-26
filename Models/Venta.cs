using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace sgidam.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public decimal TotalVenta { get; set; }
        public int? Estatus { get; set; }
        public int IdUsuario { get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }

    public class DetalleVenta
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitarioVenta { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitarioVenta;
    }
}