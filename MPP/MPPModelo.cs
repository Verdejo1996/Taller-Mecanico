using Datos;
using EE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MPP
{
    public class MPPModelo
    {
        public List<EEModelo> Listar()
        {
            Acceso Datos = new Acceso();
            DataSet ds = new DataSet();

            List<EEModelo> LModelo = new List<EEModelo>();

            ds = Datos.Leer("SP_Modelo_Listar", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    EEModelo eEModelo = new EEModelo();
                    eEModelo.idModelo = Convert.ToInt16(fila["idModelo"]);
                    eEModelo.descripcionModelo = fila["descripcionModelo"].ToString();

                    LModelo.Add(eEModelo);

                }
            }

            return LModelo;

        }
        public EEModelo BuscarPorId(int idModelo)
        {
            Acceso dt = new Acceso();
            DataSet dataSet = new DataSet();

            EEModelo unModelo = new EEModelo();

            Hashtable listaParametros = new Hashtable();

            listaParametros.Add("idModelo", idModelo);

            dataSet = dt.Leer("SP_Buscar_ModeloPorId", listaParametros);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in dataSet.Tables[0].Rows)
                {
                    unModelo.idModelo = Convert.ToInt16(fila["idModelo"]);
                    unModelo.descripcionModelo = fila["descripcionModelo"].ToString();
                }
            }
            return unModelo;
        }
    }
}
