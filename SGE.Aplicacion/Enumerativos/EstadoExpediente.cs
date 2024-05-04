namespace SGE.Aplicacion;

public enum EstadoExpediente
{   //enumerativos, establecen los estados del expedientes, algunos cambian dependiendo si cambia la etiqueta del ultimo trámite
    RecienIniciado,
    ParaResolver,
    ConResolucion,
    EnNotificacion,
    Finalizado
}
