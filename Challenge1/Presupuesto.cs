using BLL;
using EE;
using System;
using System.Data;
using System.Windows.Forms;

namespace Challenge1
{
    public partial class Presupuesto : Form
    {
        BLLVehiculo oBLLVehiculo = new BLLVehiculo();
        BLLTPVehiculo oBLLTipoVehiculo = new BLLTPVehiculo();
        BLLMarca oBLLMarca = new BLLMarca();
        BLLModelo oBLLModelo = new BLLModelo();
        BLLDesperfecto oBLLDesperfecto = new BLLDesperfecto();
        BLLDiagnostico oBLLDiagnostico = new BLLDiagnostico();

        DataSet ds = new DataSet();

        int tiempoTotal = 0;
        float costoTotal = 0f;
        float costoAcumulado = 0f;

        //DataRow dr;
        //SqlDataAdapter Da;

        public Presupuesto()
        {
            InitializeComponent();
        }

        private void Presupuesto_Load(object sender, EventArgs e)
        {

            CargarComboVehiculo();
            CargarComboTPVehiculo();
            CargarComboMarca();
            CargarComboModelo();
            CargarComboDesperfecto();
        }

        private void CargarComboVehiculo()
        {
            cmbVehiculo.DataSource = null;
            cmbVehiculo.DataSource = oBLLVehiculo.Listar();
            cmbVehiculo.ValueMember = "idVehiculo";
            cmbVehiculo.DisplayMember = "descripcionVehiculo";
            cmbVehiculo.Refresh();
        }
        private void CargarComboTPVehiculo()
        {
            cmbTPVehiculo.DataSource = null;
            cmbTPVehiculo.DataSource = oBLLTipoVehiculo.Listar();
            cmbTPVehiculo.ValueMember = "idTipoVehiculo";
            cmbTPVehiculo.DisplayMember = "descripcionTVehiculo";
            cmbTPVehiculo.Refresh();

        }
        private void CargarComboMarca()
        {
            cmbMarca.DataSource = null;
            cmbMarca.DataSource = oBLLMarca.Listar();
            cmbMarca.ValueMember = "idMarca";
            cmbMarca.DisplayMember = "marcaDescripcion";
            cmbMarca.Refresh();
        }
        private void CargarComboModelo()
        {
            cmbModelo.DataSource = null;
            cmbModelo.DataSource = oBLLModelo.Listar();
            cmbModelo.ValueMember = "idModelo";
            cmbModelo.DisplayMember = "descripcionModelo";
            cmbModelo.Refresh();
        }

        private void CargarComboDesperfecto()
        {
            cmbDesperfecto.DataSource = null;
            cmbDesperfecto.DataSource = oBLLDesperfecto.Listar();
            cmbDesperfecto.ValueMember = "idDesperfecto";
            cmbDesperfecto.DisplayMember = "descripcionDesperfecto";
            cmbDesperfecto.Refresh();

        }

        private void btbAgregar_Click(object sender, EventArgs e)
        {

            EEDesperfecto unDesperfecto = oBLLDesperfecto.BuscarPorId((int)cmbDesperfecto.SelectedValue);
            int calculoCosto = oBLLDesperfecto.CalcularCostoDesperfecto((int)cmbDesperfecto.SelectedValue);

            dataGridView1.Rows.Add(unDesperfecto.idDesperfecto.ToString(), unDesperfecto.descripcionDesperfecto, unDesperfecto.manoDeObra.ToString(), unDesperfecto.tiempo.ToString(), calculoCosto.ToString());

            tiempoTotal += unDesperfecto.tiempo;
            costoAcumulado += (calculoCosto + unDesperfecto.manoDeObra);
            costoTotal = ((costoAcumulado) * 1.1f) + (130 * tiempoTotal);

            lblCosto.Text = costoTotal.ToString();
            lblTiempo.Text = tiempoTotal.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EEDiagnostico unDiagnostico = new EEDiagnostico();

            unDiagnostico.fecha = DateTime.Today.ToString("dd/MM/yyyy");
            unDiagnostico.cliente = textCliente.Text.ToString();
            unDiagnostico.email = textEmail.Text.ToString();
            unDiagnostico.vehiculo = oBLLVehiculo.BuscarPorId((int)cmbVehiculo.SelectedValue);
            unDiagnostico.tipoVehiculo = oBLLTipoVehiculo.BuscarPorId((int)cmbTPVehiculo.SelectedValue);
            unDiagnostico.marca = oBLLMarca.BuscarPorId((int)cmbMarca.SelectedValue);
            unDiagnostico.modelo = oBLLModelo.BuscarPorId((int)cmbVehiculo.SelectedValue);
            unDiagnostico.tiempoTotal = Convert.ToInt16(lblTiempo.Text);
            unDiagnostico.costoTotal = (float)Convert.ToDouble(lblCosto.Text);

            int codigoDiagnosticoGuardado = oBLLDiagnostico.GuardarDiagnostico(unDiagnostico);


            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {

                DataGridViewCell idDesperfecto = fila.Cells[0];

                if (Convert.ToInt16(idDesperfecto.Value) != 0)
                {
                    oBLLDiagnostico.GuardarListaDesperfectos(codigoDiagnosticoGuardado, Convert.ToInt16(idDesperfecto.Value));

                }


            }
            MessageBox.Show("Diagnostico guardado con éxito ");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
