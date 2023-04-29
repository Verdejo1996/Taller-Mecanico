using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Challenge1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection();

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            conexion.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TallerMecanico;Integrated Security=True";

            SqlCommand cmd = new SqlCommand("Select Usr, Psw from Usuario where Usr ='" + txtUsr.Text + "' and Psw='" + txtPsw.Text + "'", conexion);
            conexion.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                MessageBox.Show("Bienvenido " + txtUsr.Text);
                MDI F1 = new MDI();
                F1.Show();
            }
            txtUsr.Text = null;
            txtPsw.Text = null;

            conexion.Close();
        }

        private void txtPsw_TextChanged(object sender, EventArgs e)
        {

             txtPsw.PasswordChar = '*';

        }
    }
}
