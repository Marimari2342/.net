namespace SGE.Repositorios;
using SGE.Aplicacion;

public class ExpedienteRepositorioTXT : IExpedienteRepositorio
{
    readonly string _nombreArch = "expedientes.txt";
    static int cantE=0;

    
    public void Agregar(Expediente e){
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(e.Id=cantE++);
        sw.WriteLine(e.Caratula);
        sw.WriteLine(e.FechaCreacion);
        sw.WriteLine(e.FechaUltMod);
        sw.WriteLine(e.IdUsuario);
        sw.WriteLine(e.Estado);
    }

}
