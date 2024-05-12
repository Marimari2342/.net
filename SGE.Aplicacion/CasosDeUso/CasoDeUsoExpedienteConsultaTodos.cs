namespace SGE.Aplicacion;
//Este entonces estaria???
public class CasoDeUsoExpedienteConsultaTodos
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