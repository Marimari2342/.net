namespace SGE.Aplicacion;

public class Tramite: ITramiteRepositorio, IServicioAutorizacion
{
    public int Id { get; set; }
    public int ExpedienteId { get; set; }
    public EtiquetaTramite Etiqueta { get; set; }
    public string Contenido { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime UltimaModificacion { get; set; }
    public int IdUsuarioUltimaModificacion { get; set; }
}
