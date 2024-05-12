namespace SGE.Aplicacion;

/*TramiteAlta: Puede realizar altas de trámites*/

public class CasoDeUsoTramiteAlta(ITramiteRepositorio tramiteRepositorio)
{
    private ITramiteRepositorio _tramiteRepositorio;
    private IServicioAutorizacion _servicioAutorizacion;
    public CasoDeUsoTramiteAlta(ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion servicioAutorizacion)
    {
        _tramiteRepositorio = tramiteRepositorio;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        // Verificar permisos
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario))
        {
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
}
