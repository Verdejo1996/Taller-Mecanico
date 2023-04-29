using Datos;
using EE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

//Capa de mapeo de objetos

namespace MPP
{
    public class MPPDesperfecto
    {

        //Funcion que retorna una tabla de la base de datos en modo lista
        public List<EEDesperfecto> Listar()
        {
            Acceso Datos = new Acceso();
            DataSet ds = new DataSet();

            List<EEDesperfecto> LDesperfecto = new List<EEDesperfecto>();

            ds = Datos.Leer("SP_Desperfecto_Listar", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    EEDesperfecto eEDesperfecto = new EEDesperfecto();
                    eEDesperfecto.idDesperfecto = Convert.ToInt16(fila["idDesperfecto"]);
                    eEDesperfecto.descripcionDesperfecto = fila["descripcionDesperfecto"].ToString();
                    eEDesperfecto.tiempo = Convert.ToInt16(fila["tiempo"]);
                    eEDesperfecto.manoDeObra = Convert.ToInt16(fila["manoDeObra"]);
                    LDesperfecto.Add(eEDesperfecto);

                }
            }

            return LDesperfecto;

        }

        //Funcion que retorna una tabla con el id como parametro
        public EEDesperfecto BuscarPorId(int idDesperfecto)
        {
            Acceso dt = new Acceso();
            DataSet dataSet = new DataSet();

            EEDesperfecto unDesperfecto = new EEDesperfecto();

            Hashtable listaParametros = new Hashtable();

            listaParametros.Add("idDesperfecto", idDesperfecto);

            dataSet = dt.Leer("SP_Buscar_PorId", listaParametros);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in dataSet.Tables[0].Rows)
                {
                    unDesperfecto.idDesperfecto = Convert.ToInt16(fila["idDesperfecto"]);
                    unDesperfecto.descripcionDesperfecto = fila["descripcionDesperfecto"].ToString();
                    unDesperfecto.tiempo = Convert.ToInt16(fila["tiempo"]);
                    unDesperfecto.manoDeObra = Convert.ToInt16(fila["manoDeObra"]);
                }
            }
            return unDesperfecto;
        }

        //Funcion que calcula el costo de cada desperfecto sumando el costo de cada repuesto que incluye
        public int CalcularCostoDesperfecto(int idDesperfecto)
        {
            Acceso dt = new Acceso();
            DataSet dataSet = new DataSet();

            int costo = 0;

            Hashtable listaParametros = new Hashtable();

            listaParametros.Add("idDesperfecto", idDesperfecto);

            dataSet = dt.Leer("SP_CalcularCostoDesperfecto", listaParametros);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in dataSet.Tables[0].Rows)
                {
                    costo = Convert.ToInt16(fila["costoDesperfecto"]);

                }
            }
            return costo;
        }


    }
}
