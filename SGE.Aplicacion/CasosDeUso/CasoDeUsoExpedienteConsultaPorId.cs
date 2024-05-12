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
        Expediente expediente = expedienteRepositorio.ObtenerPorId(idExpediente);

        // Obtener trámites asociados al expediente
        public List<Tramite> Ejecutar()
        {
            /*lista todos los trámites del expediente cuyo Id es el pasado como 
            parámetro --> */
            return tramiteRepositorio.ListarPorIdExpediente(idExpediente);
        }

    }
}
