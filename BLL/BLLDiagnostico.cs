using EE;
using MPP;
using System.Collections.Generic;

namespace BLL
{
    public class BLLDiagnostico
    {
        MPPDiagnostico mPPDiagnostico = new MPPDiagnostico();
        public List<EEDiagnostico> Listar()
        {

            List<EEDiagnostico> listaDiagnostico = mPPDiagnostico.Listar();
            return listaDiagnostico;

        }

        public EEDiagnostico BuscarPorId(int idDiagnostico)
        {

            return mPPDiagnostico.BuscarPorId(idDiagnostico);

        }

        public int GuardarDiagnostico(EEDiagnostico unDiagnostico)
        {
            return mPPDiagnostico.GuardarDiagnostico(unDiagnostico);
        }

        public void GuardarListaDesperfectos(int codigoDiagnosticoGuardado, int idDesperfecto)
        {
            mPPDiagnostico.GuardarListaDesperfectos(codigoDiagnosticoGuardado, idDesperfecto);
        }

        public EEDiagnostico BuscarPorIdDiagnostico(int idDiagnostico)
        {
            return mPPDiagnostico.BuscarPorIdDiagnostico(idDiagnostico);
        }

        public List<EEDesperfecto> BuscarListaDesperfectos(int idDiagnostico)
        {
            List<EEDesperfecto> listaDesperfecto = mPPDiagnostico.BuscarListaDesperfectos(idDiagnostico);
            return listaDesperfecto;
        }
    }
}
