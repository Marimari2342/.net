namespace SGE.Aplicacion;

public class Tramite: ITramiteRepositorio, IServicioAutorizacion
{
    public int Id { get; set; } //Id del trámite (identificador numérico único)
    public int ExpedienteId { get; set; } //Id del expediente al que pertenece (identificador numérico único)
    public EtiquetaTramite Etiqueta { get; set; } //etiqueta que identifica al tipo de trámite (enumerativo EtiquetaTramite)
    public string Contenido { get; set; } //texto ingresado por el usuario
    public DateTime FechaCreacion { get; set; } //fecha de creacion del expediente, se indica en la creación del tramite y no se puede cambiar
    public DateTime UltimaModificacion { get; set; } //fecha de ultima modificación, cada vez que modifico, cambia
    public int IdUsuarioUltimaModificacion { get; set; } //identificacion del ultimo usuario que modificó el tramite

    public override string ToString()
    {
    return $"Id: {Id}, Id del expediente: {ExpedienteId}, Etiqueta de tipo de tramite: {Etiqueta}, Contenido del mismo: {Contenido}, Fecha de creacion: {FechaCreacion}, Ultima modificacion: {UltimaModificacion}, Id del usuario con ultima modificacion {IdUsuarioUltimaModificacion}";
    }
}
