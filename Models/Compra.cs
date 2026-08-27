using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sgidam.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace sgidam.Models
{
    public class Compra
    {
        public int IdCompra { get; set; } 
        public string IdProveedor { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal TotalCompra { get; set; }
        public int? Estatus { get; set; }
        public int IdUsuario { get; set; } 

        public List<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>();
    }

    public class DetalleCompra
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public string CodigoLote { get; set; }  
        public decimal Subtotal => Cantidad * CostoUnitario;
    }

}