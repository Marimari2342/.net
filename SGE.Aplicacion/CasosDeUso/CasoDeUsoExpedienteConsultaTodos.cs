namespace SGE.Aplicacion;
//Este entonces estaria???
public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio)
{
    private IExpedienteRepositorio _expedienteRepositorio;
    public CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio)
    {
        _expedienteRepositorio = expedienteRepositorio;
    }
    public List<Expediente> Ejecutar()
    {
        /*lista todos los expedientes (sin sus trámites) --> */
        return expedienteRepositorio.ObtenerTodos();
    }
}