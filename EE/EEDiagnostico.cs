namespace EE
{
    public class EEDiagnostico
    {
        public int idDiagnostico { get; set; }
        public string fecha { get; set; }
        public string cliente { get; set; }
        public string email { get; set; }
        public EEVehiculo vehiculo { get; set; }
        public EETipoVehiculo tipoVehiculo { get; set; }
        public EEMarca marca { get; set; }
        public EEModelo modelo { get; set; }
        public int tiempoTotal { get; set; }
        public float costoTotal { get; set; }
        public EEDiagnostico() { }
    }
}
