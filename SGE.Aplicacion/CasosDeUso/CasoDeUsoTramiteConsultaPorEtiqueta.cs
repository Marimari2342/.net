namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta
{
    private readonly IExpedienteRepositorio _expedienteRepositorio;
    private readonly ITramiteRepositorio _tramiteRepositorio;

    public CasoDeUsoTramiteConsultaPorEtiqueta(IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio)
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