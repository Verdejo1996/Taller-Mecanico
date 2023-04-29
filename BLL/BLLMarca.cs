using EE;
using MPP;
using System.Collections.Generic;

namespace BLL
{
    public class BLLMarca
    {
        MPPMarca mPPMarca = new MPPMarca();
        public List<EEMarca> Listar()
        {

            List<EEMarca> listaMarca = mPPMarca.Listar();
            return listaMarca;

        }

        public EEMarca BuscarPorId(int idMarca)
        {

            return mPPMarca.BuscarPorId(idMarca);

        }
    }


}
