using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Entidades.Entidades
{
    public class Venta

    {
        public int VentaId { get; set; }
        public string FechaVenta { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public double Total { get; set; }
    }
}
