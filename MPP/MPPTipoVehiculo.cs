using Datos;
using EE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPP
{
    public class MPPTipoVehiculo
    {
        public List<EETipoVehiculo> Listar()
        {
            Acceso Datos = new Acceso();
            DataSet ds = new DataSet();

            List<EETipoVehiculo> LTPVehiculo = new List<EETipoVehiculo>();

            ds = Datos.Leer("SP_TipoVehiculo_Listar", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    EETipoVehiculo eETPVehiculo = new EETipoVehiculo();
                    eETPVehiculo.idTipovehiculo = Convert.ToInt16(fila["idTipovehiculo"]);
                    eETPVehiculo.descripcionTVehiculo = fila["descripcionTVehiculo"].ToString();

                    LTPVehiculo.Add(eETPVehiculo);

                }
            }

            return LTPVehiculo;

        }
        public EETipoVehiculo BuscarPorId(int idTipoVehiculo)
        {
            Acceso dt = new Acceso();
            DataSet dataSet = new DataSet();

            EETipoVehiculo unTipoVehiculo = new EETipoVehiculo();

            Hashtable listaParametros = new Hashtable();

            listaParametros.Add("idTipoVehiculo", idTipoVehiculo);

            dataSet = dt.Leer("SP_Buscar_TipoVehiculoPorId", listaParametros);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in dataSet.Tables[0].Rows)
                {
                    unTipoVehiculo.idTipovehiculo = Convert.ToInt16(fila["idTipoVehiculo"]);
                    unTipoVehiculo.descripcionTVehiculo = fila["descripcionTVehiculo"].ToString();
                }
            }
            return unTipoVehiculo;
        }
    }
}
