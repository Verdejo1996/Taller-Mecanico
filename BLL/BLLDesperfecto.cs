using EE;
using MPP;
using System.Collections.Generic;

//Capa de negocio

namespace BLL
{
    public class BLLDesperfecto
    {
        MPPDesperfecto mPPDesperfecto = new MPPDesperfecto();
        public List<EEDesperfecto> Listar()
        {

            List<EEDesperfecto> listaDesperfecto = mPPDesperfecto.Listar();
            return listaDesperfecto;

        }

        public EEDesperfecto BuscarPorId(int idDespefecto)
        {

            return mPPDesperfecto.BuscarPorId(idDespefecto);

        }

        public int CalcularCostoDesperfecto(int idDespefecto)
        {
            return mPPDesperfecto.CalcularCostoDesperfecto(idDespefecto);
        }
    }
}
