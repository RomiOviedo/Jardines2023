using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Comun.Interfaces
{
    public interface IRepositorioVentas
    {
        List<Venta> GetVentas();
    }
}
