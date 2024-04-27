namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId
{
    private readonly IExpedienteRepositorio _expedienteRepositorio;
    private readonly ITramiteRepositorio _tramiteRepositorio;

    public CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio)
    {
        _expedienteRepositorio = expedienteRepositorio;
        _tramiteRepositorio = tramiteRepositorio;
    }

    public Expediente ConsultarConTramites(int idExpediente)
    {
        // Obtener expediente
        Expediente expediente = _expedienteRepositorio.ObtenerPorId(idExpediente);

        // Obtener trámites asociados al expediente
        //IEnumerable;
    }
}
