using Jardines2023.Comun.Interfaces;
using Jardines2023.Comun.Repositorios;
using Jardines2023.Datos.Repositorios;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Servicios.Servicios
{
    public class ServiciosVentas : IServiciosVentas
    {
        private readonly IRepositorioVentas _repositorio;
        private readonly IRepositorioClientes _repoClientes;

        public ServiciosVentas()
        {
        _repositorio: new RepositorioVentas();
        _repoClientes: new RepositorioClientes();
        }
        public List<Venta>GetVentas()
        {
            try
            {
                var lista = _repositorio.GetVentas();
                foreach (var item in lista)
                {
                    item.Cliente = _repoClientes.GetClientesPorId(item.ClienteId);
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
