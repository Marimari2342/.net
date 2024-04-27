namespace SGE.Aplicacion;

public class ServicioActualizacionEstado
{
    private readonly EspecificacionCambioEstado _especificacion;

    public ServicioActualizacionEstado(EspecificacionCambioEstado especificacion)
    {
        _especificacion = especificacion;
    }

    public void ActualizarEstado(Expediente expediente, Tramite ultimoTramite)
    {
        EstadoExpediente nuevoEstado = _especificacion.ObtenerNuevoEstado(ultimoTramite.Etiqueta, expediente.Estado);
        expediente.Estado = nuevoEstado;
    }
}
