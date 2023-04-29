using EE;
using MPP;
using System.Collections.Generic;

namespace BLL
{
    public class BLLModelo
    {
        MPPModelo mPPModelo = new MPPModelo();
        public List<EEModelo> Listar()
        {

            List<EEModelo> listaModelo = mPPModelo.Listar();
            return listaModelo;

        }

        public EEModelo BuscarPorId(int idModelo)
        {

            return mPPModelo.BuscarPorId(idModelo);

        }
    }
}
