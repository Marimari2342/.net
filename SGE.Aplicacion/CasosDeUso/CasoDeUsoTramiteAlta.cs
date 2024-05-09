namespace SGE.Aplicacion;

/*TramiteAlta: Puede realizar altas de trámites*/

public class CasoDeUsoTramiteAlta(ITramiteRepositorio tramiteRepositorio)
{
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
        tramite.Id = tramiteRepositorio.ObtenerSiguienteId(); //Corresponde al repositorio otorgar el Id

        // Asignar fecha de creación y modificación
        tramite.FechaCreacion = DateTime.Now;
        tramite.FechaModificacion = DateTime.Now;

        // Agregar etiqueta tramite
        tramite.AgregarEtiqueta = tramiteRepositorio.AgregarEtiq();

        // Guardar tramite en el repositorio
        tramiteRepositorio.Agregar(tramite);
    }
}
