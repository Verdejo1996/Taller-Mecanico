using Datos;
using EE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPP
{
    public class MPPDiagnostico
    {
        public List<EEDiagnostico> Listar()
        {
            Acceso Datos = new Acceso();
            DataSet ds = new DataSet();

            List<EEDiagnostico> LDiagnostico = new List<EEDiagnostico>();

            ds = Datos.Leer("SP_Diagnostico_Listar", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    EEDiagnostico eEDiagnostico = new EEDiagnostico();
                    eEDiagnostico.idDiagnostico = Convert.ToInt16(fila["idDiagnostico"]);
                    eEDiagnostico.cliente = fila["cliente"].ToString();
                    eEDiagnostico.vehiculo = (EEVehiculo)fila["vehiculo"];
                    eEDiagnostico.tipoVehiculo = (EETipoVehiculo)fila["tipoVehiculo"];
                    eEDiagnostico.marca = (EEMarca)fila["marca"];
                    eEDiagnostico.modelo = (EEModelo)fila["modelo"];


                    LDiagnostico.Add(eEDiagnostico);

                }
            }

            return LDiagnostico;

        }
        public EEDiagnostico BuscarPorId(int idDiagnostico)
        {
            Acceso dt = new Acceso();
            DataSet dataSet = new DataSet();

            EEDiagnostico unDiagnostico = new EEDiagnostico();

            Hashtable listaParametros = new Hashtable();

            listaParametros.Add("idDiagnostico", idDiagnostico);

            dataSet = dt.Leer("SP_Buscar_PorId", listaParametros);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in dataSet.Tables[0].Rows)
                {
                    EEDiagnostico eEDiagnostico = new EEDiagnostico();
                    eEDiagnostico.idDiagnostico = Convert.ToInt16(fila["idDiagnostico"]);
                    eEDiagnostico.cliente = fila["cliente"].ToString();
                    eEDiagnostico.vehiculo = (EEVehiculo)fila["vehiculo"];
                    eEDiagnostico.tipoVehiculo = (EETipoVehiculo)fila["tipoVehiculo"];
                    eEDiagnostico.marca = (EEMarca)fila["marca"];
                    eEDiagnostico.modelo = (EEModelo)fila["modelo"];
                }
            }
            return unDiagnostico;
        }

        //Funcion que guarda el diagnostico cargado en el formulario principal en la base de datos
        public int GuardarDiagnostico(EEDiagnostico unDiagnostico)
        {
            Acceso dt = new Acceso();
            DataSet dataSet = new DataSet();

            Hashtable listaParametros = new Hashtable();

            listaParametros.Add("fecha", unDiagnostico.fecha);
            listaParametros.Add("cliente", unDiagnostico.cliente);
            listaParametros.Add("email", unDiagnostico.email);
            listaParametros.Add("idVehiculo", unDiagnostico.vehiculo.idVehiculo);
            listaParametros.Add("idTipoVehiculo", unDiagnostico.tipoVehiculo.idTipovehiculo);
            listaParametros.Add("idMarca", unDiagnostico.marca.idMarca);
            listaParametros.Add("idModelo", unDiagnostico.modelo.idModelo);
            listaParametros.Add("tiempoTotal", unDiagnostico.tiempoTotal);
            listaParametros.Add("costoTotal", unDiagnostico.costoTotal);

            dataSet = dt.Leer("SP_Escribir_Diagnostico", listaParametros);

            return BuscarUltimoId();
        }

        //Funcion que retorna el ultimo id generado en la tabla de Diagnostico
        private int BuscarUltimoId()
        {
            Acceso Datos = new Acceso();
            DataSet ds = new DataSet();

            int idDiagnostico = 0;

            ds = Datos.Leer("SP_BuscarUltimoId", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    idDiagnostico = Convert.ToInt16(fila["idDiagnostico"]);

                }
            }
            return idDiagnostico;
        }

        //Funcion que inserta en la lista de desperfectos los nuevos id generados por el nuevo diganostico
        public void GuardarListaDesperfectos(int codigoDiagnosticoGuardado, int idDesperfecto)
        {
            Acceso dt = new Acceso();
            DataSet dataSet = new DataSet();

            Hashtable listaParametros = new Hashtable();

            listaParametros.Add("idDiagnostico", codigoDiagnosticoGuardado);
            listaParametros.Add("idDesperfecto", idDesperfecto);

            dataSet = dt.Leer("SP_Escribir_ListaDesperfecto", listaParametros);
        }

        public EEDiagnostico BuscarPorIdDiagnostico(int idDiagnostico)
        {
            Acceso dt = new Acceso();
            DataSet dataSet = new DataSet();

            MPPVehiculo mPPVehiculo = new MPPVehiculo();
            MPPTipoVehiculo mPPTipoVehiculo = new MPPTipoVehiculo();
            MPPModelo mPPModelo = new MPPModelo();
            MPPMarca mPPMarca = new MPPMarca();

            EEDiagnostico unDiagnostico = new EEDiagnostico();

            Hashtable listaParametros = new Hashtable();

            listaParametros.Add("idDiagnostico", idDiagnostico);

            dataSet = dt.Leer("SP_Buscar_PorIdDiagnostico", listaParametros);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in dataSet.Tables[0].Rows)
                {
                    unDiagnostico.idDiagnostico = Convert.ToInt16(fila["idDiagnostico"]);
                    unDiagnostico.cliente = fila["cliente"].ToString();
                    unDiagnostico.email = fila["email"].ToString();
                    unDiagnostico.vehiculo = mPPVehiculo.BuscarPorId(Convert.ToInt16(fila["idVehiculo"]));
                    unDiagnostico.tipoVehiculo = mPPTipoVehiculo.BuscarPorId(Convert.ToInt16(fila["idTipoVehiculo"]));
                    unDiagnostico.marca = mPPMarca.BuscarPorId(Convert.ToInt16(fila["idMarca"]));
                    unDiagnostico.modelo = mPPModelo.BuscarPorId(Convert.ToInt16(fila["idModelo"]));
                    unDiagnostico.tiempoTotal = Convert.ToInt16(fila["tiempoTotal"]);
                    unDiagnostico.costoTotal = Convert.ToInt16(fila["costoTotal"]);
                }
            }
            return unDiagnostico;
        }

        public List<EEDesperfecto> BuscarListaDesperfectos(int idDiagnostico)
        {
            Acceso Datos = new Acceso();
            DataSet ds = new DataSet();

            List<EEDesperfecto> LDesperfecto = new List<EEDesperfecto>();

            Hashtable listaParametros = new Hashtable();

            listaParametros.Add("idDiagnostico", idDiagnostico);

            ds = Datos.Leer("SP_Listar_DesperfectosPorDiagnostico", listaParametros);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    EEDesperfecto eEDesperfecto = new EEDesperfecto();
                    eEDesperfecto.idDesperfecto = Convert.ToInt16(fila["idDesperfecto"]);
                    eEDesperfecto.descripcionDesperfecto = fila["descripcionDesperfecto"].ToString();
                    eEDesperfecto.manoDeObra = Convert.ToInt16(fila["manoDeObra"]);
                    eEDesperfecto.tiempo = Convert.ToInt16(fila["tiempo"]);


                    LDesperfecto.Add(eEDesperfecto);

                }
            }

            return LDesperfecto;
        }
    }
}
