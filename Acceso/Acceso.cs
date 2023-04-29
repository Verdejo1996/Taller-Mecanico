using System.Collections;
using System.Data;
using System.Data.SqlClient;

//Capa de acceso a Base de Datos

namespace Datos
{
    public class Acceso
    {
        private SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TallerMecanico;Integrated Security=True");
        private SqlTransaction transaction;
        private SqlCommand cmd;

        public void Abrir()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TallerMecanico;Integrated Security=True";
            con.Open();
        }
        public void Cerrar()
        {
            con.Close();
        }
        public DataSet Leer(string consulta, Hashtable Qdatos)
        {
            DataSet ds = new DataSet();
            cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.StoredProcedure;


            if (Qdatos != null)
            {
                foreach (string d in Qdatos.Keys)
                {
                    cmd.Parameters.AddWithValue(d, Qdatos[d]);
                }


            }
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(ds);

            return ds;

        }
    }
}
