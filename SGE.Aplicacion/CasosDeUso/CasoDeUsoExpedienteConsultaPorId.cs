namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId
{
    private IExpedienteRepositorio _expedienteRepositorio;
    private ITramiteRepositorio _tramiteRepositorio;

    public CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio)
    {
        _expedienteRepositorio = expedienteRepositorio;
        _tramiteRepositorio = tramiteRepositorio;
    }
    /*permite la consulta de un expediente junto con todos sus 
    trámites, utilizando el Id del expediente como referencia
    (devolverá tipo una lista del expediente y sus trámites)*/
  public Expediente ConsultarConTramites(int idExpediente)
{
    // Obtener expediente
    Expediente expediente = _expedienteRepositorio.ObtenerPorId(idExpediente);

    // Obtener trámites asociados al expediente
    List<Tramite> tramites = _tramiteRepositorio.ListarPorIdExpediente(idExpediente);
    
    // Asignar los trámites al expediente
    expediente.Tramites = tramites;

    return expediente;
}

}
