using System;
using System.Collections.Generic;

namespace sgidam.Models
{
    public class Devolucion
    {
        public int IdDevolucion { get; set; }
        public int IdVentaOriginal { get; set; }
        public int? IdVentaNueva { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int IdUsuario { get; set; }
        public string Motivo { get; set; }
        public int Estatus { get; set; }
        public List<DetalleDevolucion> Detalles { get; set; } = new List<DetalleDevolucion>();
    }

    public class DetalleDevolucion
    {
        public int IdDetalleDevolucion { get; set; }
        public int IdDevolucion { get; set; }
        public int IdProducto { get; set; }
        public int CantidadDevuelta { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal PrecioUnitarioVenta { get; set; }
    }
}