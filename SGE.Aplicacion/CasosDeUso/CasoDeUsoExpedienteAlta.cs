namespace SGE.Aplicacion;

/*
ExpedienteAlta: Puede realizar altas de expedientes
Todas las operaciones relacionadas con las operaciones Tramite y 
Expediente deben llevar consigo la informacion del ID de usuario 
que las esté ejecutando.

Se debe garantizar que para las operaciones de alta, baja y modificación 
se verifique la autorización del usuario antes de proceder. Por lo 
tanto, el método Ejecutar de estos casos de uso deberá recibir también
el Id del usuario como parámetro.

Chequear que no se intenta acceder a un repos que no existe

En los casos uso try catch o como?
*/

public class CasoDeUsoExpedienteAlta
{
    private readonly IExpedienteRepositorio _expedienteRepositorio;

    public CasoDeUsoExpedienteAlta(IExpedienteRepositorio expedienteRepositorio)
    {
        _expedienteRepositorio = expedienteRepositorio;
    }

    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        // Verificar permisos
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar esta operación.");
        }

        // Validar expediente
        ExpedienteValidador.Validar(expediente);

        // Asignar Id
        expediente.Id = _expedienteRepositorio.ObtenerSiguienteId(); //Corresponde al repositorio otorgar el Id

        // Asignar fecha de creación y modificación
        expediente.FechaCreacion = DateTime.Now;
        expediente.FechaModificacion = DateTime.Now;

        // Guardar expediente en el repositorio
        _expedienteRepositorio.Agregar(expediente);
    }
}
