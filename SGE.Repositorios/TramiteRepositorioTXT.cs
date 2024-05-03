namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteTXT : ITramiteRepositorio
{
    readonly string _nombreArch = "tramites.txt";
    static int cantT=0;

    public void Agregar(Tramite t){
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(t.Id=cantT++);  //?
        sw.WriteLine(t.ExpedienteId);
        sw.WriteLine(t.Etiqueta);
        sw.WriteLine(t.Contenido);
        sw.WriteLine(t.FechaCreacion);
        sw.WriteLine(t.UltimaModificacion);
        sw.WriteLine(t.IdUsuarioUltimaModificacion);
        
    }

}
