using EE;
using MPP;
using System.Collections.Generic;

namespace BLL
{
    public class BLLTPVehiculo
    {
        MPPTipoVehiculo mPPTipoVehiculo = new MPPTipoVehiculo();
        public List<EETipoVehiculo> Listar()
        {

            List<EETipoVehiculo> listaTipoVehiculos = mPPTipoVehiculo.Listar();
            return listaTipoVehiculos;

        }

        public EETipoVehiculo BuscarPorId(int idTipovehiculo)
        {

            return mPPTipoVehiculo.BuscarPorId(idTipovehiculo);

        }
    }
}
