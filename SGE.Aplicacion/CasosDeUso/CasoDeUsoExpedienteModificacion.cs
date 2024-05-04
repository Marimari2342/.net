namespace SGE.Aplicacion;

/*ExpedienteModificacion: Puede realizar modificaciones de expedientes
Se debe garantizar que para las operaciones de alta, baja y modificación se verifique la autorización del
usuario antes de proceder. Por lo tanto, el método Ejecutar de estos casos de uso deberá recibir también el
Id del usuario como parámetro.*/

public class CasoDeUsoExpedienteModificacion
{
    private readonly IExpedienteRepositorio _expedienteRepositorio;

    public CasoDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio)
    {
        _expedienteRepositorio = expedienteRepositorio;
    }

    public void Ejecutar(Expediente expediente, int idUsuario)
    {

        // Asignar fecha de modificación
        expediente.FechaModificacion = DateTime.Now;
}