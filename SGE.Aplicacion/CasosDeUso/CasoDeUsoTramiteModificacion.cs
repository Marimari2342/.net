namespace SGE.Aplicacion;

/*TramiteModificacion: Puede realizar modificaciones de trámites*/
public class CasoDeUsoTramiteModificacion(ITramiteRepositorio tramiteRepositorio)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        // Verificar permisos
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario))
       {
        // Validar tramite
        TramiteValidador.Validar(tramite);
        // Asignar fecha de modificación
        tramite.FechaModificacion = DateTime.Now;
        // Guardar tramite en el repositorio
        _tramiteRepositorio.Modificar(tramite);

       }
    }
}