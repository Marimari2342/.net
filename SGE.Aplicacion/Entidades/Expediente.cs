namespace SGE.Aplicacion;

public class Expediente: IExpedienteRepositorio, IServicioAutorizacion
{
    public int Id { get; set; }
    //Probando Mariaaannn
    public string Caratula { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime UltimaModificacion { get; set; }
    public int IdUsuarioUltimaModificacion { get; set; }
    public EstadoExpediente Estado { get; set; }

    public override string ToString()
    {
    return $"Id: {Id}, Caratula: {Caratula}, Fecha de creación: {FechaCreacion}, Última modificación: {UltimaModificacion}, Id del usuario con última modificación: {IdUsuarioUltimaModificacion}, Estado del expediente: {EstadoExpediente}";
    }
}
