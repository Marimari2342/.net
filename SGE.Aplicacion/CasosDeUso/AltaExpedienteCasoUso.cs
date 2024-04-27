namespace SGE.Aplicacion;

public class AltaExpedienteCasoUso
{
    private readonly IExpedienteRepositorio _expedienteRepositorio;

    public AltaExpedienteCasoUso(IExpedienteRepositorio expedienteRepositorio)
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
        expediente.Id = _expedienteRepositorio.ObtenerSiguienteId();

        // Asignar fecha de creación y modificación
        expediente.FechaCreacion = DateTime.Now;
        expediente.FechaModificacion = DateTime.Now;

        // Guardar expediente en el repositorio
        _expedienteRepositorio.Agregar(expediente);
    }
}
