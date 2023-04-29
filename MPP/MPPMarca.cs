using Datos;
using EE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MPP
{
    public class MPPMarca
    {
        public List<EEMarca> Listar()
        {
            Acceso Datos = new Acceso();
            DataSet ds = new DataSet();

            List<EEMarca> LMarca = new List<EEMarca>();

            ds = Datos.Leer("SP_Marca_Listar", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    EEMarca eEMarca = new EEMarca();
                    eEMarca.idMarca = Convert.ToInt16(fila["idMarca"]);
                    eEMarca.marcaDescripcion = fila["marcaDescripcion"].ToString();

                    LMarca.Add(eEMarca);

                }
            }

            return LMarca;

        }

        public EEMarca BuscarPorId(int idMarca)
        {
            Acceso dt = new Acceso();
            DataSet dataSet = new DataSet();

            EEMarca unaMarca = new EEMarca();

            Hashtable listaParametros = new Hashtable();

            listaParametros.Add("idMarca", idMarca);

            dataSet = dt.Leer("SP_Buscar_PorMarcaId", listaParametros);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in dataSet.Tables[0].Rows)
                {
                    unaMarca.idMarca = Convert.ToInt16(fila["idMarca"]);
                    unaMarca.marcaDescripcion = fila["marcaDescripcion"].ToString();
                }
            }
            return unaMarca;
        }
    }
}
