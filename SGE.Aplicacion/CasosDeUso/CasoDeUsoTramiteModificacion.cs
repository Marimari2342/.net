namespace SGE.Aplicacion;

/*TramiteModificacion: Puede realizar modificaciones de trámites*/
public class CasoDeUsoTramiteModificacion
{
    private readonly ITramiteRepositorio _tramiteRepositorio;

    public CasoDeUsoTramiteModificacion(ITramiteRepositorio tramiteRepositorio)
    {
        _tramiteRepositorio = tramiteRepositorio;
    }

    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        // Verificar permisos
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteModificacion))
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar esta operación.");
        }

        // Validar tramite
        TramiteValidador.Validar(tramite);

        // Asignar fecha de modificación
        tramite.FechaModificacion = DateTime.Now;

        // Guardar tramite en el repositorio
        _tramiteRepositorio.Modificar(tramite);
    }
}