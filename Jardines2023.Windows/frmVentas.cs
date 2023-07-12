using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Servicios;
using Jardines2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmVentas : Form
    {
        private readonly ServiciosVentas _servicio;
        private List<Venta> lista;


        public frmVentas()
        {
            InitializeComponent();
            _servicio = new ServiciosVentas();

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
        private void RecargarGrilla()
        {
            try
            {

                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var venta in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, venta);
                GridHelper.AgregarFila(dgvDatos, r);
            }
        }


    }
}
