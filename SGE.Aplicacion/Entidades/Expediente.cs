namespace SGE.Aplicacion;

public class Expediente
{
    public int Id { get; set; }
    //Probando Mariaaannn
    public string Caratula { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime UltimaModificacion { get; set; }
    public int IdUsuarioUltimaModificacion { get; set; }
    public EstadoExpediente Estado { get; set; }
}
