namespace SGE.Aplicacion;

/*TramiteBaja: Puede realizar bajas de trámites*/

public class CasoDeUsoTramiteBaja(ITramiteRepositorio tramiteRepositorio)
{
    private readonly ITramiteRepositorio _tramiteRepositorio;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public CasoDeUsoTramiteBaja(ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion servicioAutorizacion)
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

        // Eliminar expediente en el repositorio
        _tramiteRepositorio.Eliminar(tramite);

        }

        /* Si elimino el tramite... en algún lado tengo que cambiar 
        la etiqueta tramite a la etiqueta del tramite anterior y a su vez
        mirar que esa nueva etiqueta no me cambie el estado del expediente
        que contiene este trámite*/
    }
}