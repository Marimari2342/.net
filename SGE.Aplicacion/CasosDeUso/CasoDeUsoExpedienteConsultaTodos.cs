namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio)
{
    public List<Expediente> Ejecutar()
    {
        /*lista todos los expedientes (sin sus trámites) --> */
        return expedienteRepositorio.ObtenerTodos();
    }
}