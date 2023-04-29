using Datos;
using EE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MPP
{
    public class MPPRepuesto
    {
        public List<EERepuesto> Listar()
        {
            Acceso Datos = new Acceso();
            DataSet ds = new DataSet();

            List<EERepuesto> LRepuesto = new List<EERepuesto>();

            ds = Datos.Leer("SP_Repuesto_Listar", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    EERepuesto eERepuesto = new EERepuesto();
                    eERepuesto.idRepuesto = Convert.ToInt16(fila["idRepuesto"]);
                    eERepuesto.nombreRepuesto = fila["nombreRepuesto"].ToString();
                    eERepuesto.costoRepuesto = (float)fila["costoRepuesto"];


                    LRepuesto.Add(eERepuesto);

                }
            }

            return LRepuesto;

        }
        public EERepuesto BuscarPorId(int idRepuesto)
        {
            Acceso dt = new Acceso();
            DataSet dataSet = new DataSet();

            EERepuesto unRepuesto = new EERepuesto();

            Hashtable listaParametros = new Hashtable();

            listaParametros.Add("idModelo", idRepuesto);

            dataSet = dt.Leer("SP_Buscar_RepuestoPorId", listaParametros);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in dataSet.Tables[0].Rows)
                {
                    unRepuesto.idRepuesto = Convert.ToInt16(fila["idRepuesto"]);
                    unRepuesto.nombreRepuesto = fila["nombreRepuesto"].ToString();
                    unRepuesto.costoRepuesto = (float)fila["costoRepuesto"];
                }
            }
            return unRepuesto;
        }
    }
}
