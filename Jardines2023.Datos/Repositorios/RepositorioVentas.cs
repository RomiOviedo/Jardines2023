using Jardines2023.Comun.Interfaces;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Datos.Repositorios
{
    public class RepositorioVentas : IRepositorioVentas
    {
        private readonly string cadenaConexion;

        public RepositorioVentas()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public List<Venta> GetVentas()
        {
            List<Venta> lista = new List<Venta>();
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                  string selectQuery = @"SELECT VentaId, FechaVenta, ClienteId 
                                    FROM Ventas 
                                    ORDER BY ClienteId, VentaId";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var venta = ConstruirVenta(reader);
                                lista.Add(venta);
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private Venta ConstruirVenta(SqlDataReader reader)
        {
            return new Venta()
            {
                VentaId = reader.GetInt32(0),
                FechaVenta = reader.GetString(1),
                ClienteId = reader.GetInt32(2),
                Total= reader.GetDouble(3)
            };

        }
    }
}
