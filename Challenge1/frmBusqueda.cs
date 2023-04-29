using BLL;
using EE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Challenge1
{
    public partial class frmBusqueda : Form
    {

        BLLDiagnostico oBLLDiagnostico = new BLLDiagnostico();
        public frmBusqueda()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBusqueda_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EEDiagnostico unDiagnostico = oBLLDiagnostico.BuscarPorIdDiagnostico(Convert.ToInt16(txtDiagnostico.Text));
            
            dataGridBusqueda.Rows.Clear();

            lblCliente.Text = unDiagnostico.cliente;
            lblEmail.Text = unDiagnostico.email;
            lblVehiculo.Text = unDiagnostico.vehiculo.descripcionVehiculo;
            lblTipoVehiculo.Text = unDiagnostico.tipoVehiculo.descripcionTVehiculo;
            lblMarca.Text = unDiagnostico.marca.marcaDescripcion;
            lblModelo.Text = unDiagnostico.modelo.descripcionModelo;
            lblCosto.Text = unDiagnostico.costoTotal.ToString();
            lblTiempo.Text = unDiagnostico.tiempoTotal.ToString();

            List<EEDesperfecto> listaDesperfecto = oBLLDiagnostico.BuscarListaDesperfectos(Convert.ToInt16(txtDiagnostico.Text));

            foreach (EEDesperfecto unDesperfecto in listaDesperfecto)
            {
                dataGridBusqueda.Rows.Add(unDesperfecto.idDesperfecto, unDesperfecto.descripcionDesperfecto, unDesperfecto.manoDeObra, unDesperfecto.tiempo);
            }
        }
    }
}
