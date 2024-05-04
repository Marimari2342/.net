namespace SGE.Aplicacion;

/*TramiteAlta: Puede realizar altas de trámites*/

public class CasoDeUsoTramiteAlta
{
    private readonly ITramiteRepositorio _tramiteRepositorio;

    public CasoDeUsoTramiteAlta(ITramiteRepositorio tramiteRepositorio)
    {
        _tramiteRepositorio = tramiteRepositorio;
    }

    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        // Verificar permisos
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteAlta))
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar esta operación.");
        }

        // Validar tramite
        TramiteValidador.Validar(tramite);

        // Asignar Id [ObtenerSiguienteId() donde iría???]
        tramite.Id = _tramiteRepositorio.ObtenerSiguienteId();

        // Asignar fecha de creación y modificación
        tramite.FechaCreacion = DateTime.Now;
        tramite.FechaModificacion = DateTime.Now;

        // Guardar tramite en el repositorio
        _tramiteRepositorio.Agregar(tramite);
    }
}
