using EE;
using MPP;
using System.Collections.Generic;

namespace BLL
{
    public class BLLVehiculo
    {
        MPPVehiculo mPPVehiculo = new MPPVehiculo();
        public List<EEVehiculo> Listar()
        {

            List<EEVehiculo> listaVehiculos = mPPVehiculo.Listar();
            return listaVehiculos;

        }

        public EEVehiculo BuscarPorId(int idVehiculo)
        {

            return mPPVehiculo.BuscarPorId(idVehiculo);

        }
    }
}
