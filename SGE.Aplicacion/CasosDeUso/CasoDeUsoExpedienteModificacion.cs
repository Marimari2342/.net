namespace SGE.Aplicacion;

/*ExpedienteModificacion: Puede realizar modificaciones de expedientes
Se debe garantizar que para las operaciones de alta, baja y modificación se verifique la autorización del
usuario antes de proceder. Por lo tanto, el método Ejecutar de estos casos de uso deberá recibir también el
Id del usuario como parámetro.*/

public class CasoDeUsoExpedienteModificacion
{
    private IExpedienteRepositorio _expedienteRepositorio;
    private IServicioAutorizacion _servicioAutorizacion;

    public CasoDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion)
    {
        _expedienteRepositorio = expedienteRepositorio;
         _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario)){
         ExpedienteValidador.Validar(expediente);
        // Asignar fecha de modificación
         expediente.FechaModificacion = DateTime.Now;
         expedienteRepositorio.Modificar(expediente);
        }
    }
}