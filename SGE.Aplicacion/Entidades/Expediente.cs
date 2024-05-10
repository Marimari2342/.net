namespace SGE.Aplicacion;

public class Expediente: IExpedienteRepositorio, ITramiteRepositorio, IServicioAutorizacion
{
    public int Id { get; set; } //Id del expediente (identificador numérico único)
    public string Caratula { get; set; } //texto ingresado por el usuario, no puede estar vacío
    public DateTime FechaCreacion { get; set; } //fecha de creacion del expediente, se indica en la creación del espediente y no se puede cambiar
    public DateTime UltimaModificacion { get; set; } //fecha de ultima modificación, cada vez que modifico, cambia
    public int IdUsuarioUltimaModificacion { get; set; } //identificacion del ultimo usuario que modificó el expediente
    public EstadoExpediente Estado { get; set; } //posibles valores enumerativos = EstadoExpediente

public override string ToString()
    {
    return $"Id: {Id}, Caratula: {Caratula}, Fecha de creación: {FechaCreacion}, Última modificación: {UltimaModificacion}, Id del usuario con última modificación: {IdUsuarioUltimaModificacion}, Estado del expediente: {EstadoExpediente}";
    }
}
