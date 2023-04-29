using Datos;
using System.Collections.Generic;
using System;
using System.Data;
using EE;
using System.Collections;

namespace MPP
{
    public class MPPVehiculo
    {
        public List<EEVehiculo> Listar()
        {
            Acceso Datos = new Acceso();
            DataSet ds = new DataSet();

            List<EEVehiculo> LEVehiculos = new List<EEVehiculo>();

            ds = Datos.Leer("SP_Vehiculo_Listar", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    EEVehiculo eEVehiculo = new EEVehiculo();
                    eEVehiculo.idVehiculo = Convert.ToInt16(fila["idVehiculo"]);
                    eEVehiculo.descripcionVehiculo = fila["descripcionVehiculo"].ToString();

                    LEVehiculos.Add(eEVehiculo);

                }
            }

            return LEVehiculos;

        }

        public EEVehiculo BuscarPorId(int idVehiculo)
        {
            Acceso dt = new Acceso();
            DataSet dataSet = new DataSet();

            EEVehiculo unVehiculo = new EEVehiculo();

            Hashtable listaParametros = new Hashtable();

            listaParametros.Add("idVehiculo", idVehiculo);

            dataSet = dt.Leer("SP_Buscar_VehiculoPorId", listaParametros);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in dataSet.Tables[0].Rows)
                {
                    unVehiculo.idVehiculo = Convert.ToInt16(fila["idVehiculo"]);
                    unVehiculo.descripcionVehiculo = fila["descripcionVehiculo"].ToString();
                }
            }
            return unVehiculo;
        }
    }
}
