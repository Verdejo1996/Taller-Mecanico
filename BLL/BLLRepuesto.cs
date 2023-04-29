using EE;
using MPP;
using System.Collections.Generic;

namespace BLL
{
    public class BLLRepuesto
    {
        MPPRepuesto mPPRepuesto = new MPPRepuesto();
        public List<EERepuesto> Listar()
        {

            List<EERepuesto> listaRepuestos = mPPRepuesto.Listar();
            return listaRepuestos;

        }

        public EERepuesto BuscarPorId(int idRepuesto)
        {

            return mPPRepuesto.BuscarPorId(idRepuesto);

        }
    }
}
