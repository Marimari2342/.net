namespace SGE.Repositorios;
using SGE.Aplicacion;

public class TramiteRepositorioTXT : ITramiteRepositorio
{
  readonly string _nombreArch = "tramites.txt";

  //Retorno el id del tramite que se quiere dar de alta
  public int ObtenerSiguienteId()
  {
    int id = 0;
    if (File.Exists(_nombreArch))
    {
      List<Tramite> list = ListarTramites(); // Lista de ids sería mejor?
      foreach (Tramite t in list)
      {
        id = t.Id;
      }
    }
    return ++id;
  }

  public void Agregar(Tramite t)
  {
    using var sw = new StreamWriter(_nombreArch, true);
    sw.WriteLine(t.Id);
    sw.WriteLine(t.ExpedienteId);
    sw.WriteLine(t.Etiqueta);
    sw.WriteLine(t.Contenido);
    sw.WriteLine(t.FechaCreacion);
    sw.WriteLine(t.UltimaModificacion);
    sw.WriteLine(t.IdUsuarioUltimaModificacion);
    sw.Close();
  }

  private List<Tramite> ListarTramites()
  {
    List<Tramite> resultado = new List<Tramite>();
    using var sr = new StreamReader(_nombreArch);
    while (!sr.EndOfStream)
    {
      var tramite = new Tramite();
      tramite.Id = int.Parse(sr.ReadLine() ?? "");
      tramite.ExpedienteId = int.Parse(sr.ReadLine() ?? "");
      tramite.Etiqueta = Enum.Parse<EtiquetaTramite>(sr.ReadLine() ?? "");
      tramite.Contenido = (sr.ReadLine() ?? "");
      tramite.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
      tramite.FechaUltMod = DateTime.Parse(sr.ReadLine() ?? "");
      tramite.IdUsuario = int.Parse(sr.ReadLine() ?? "");
      resultado.Add(tramite);
    }
    sr.Close();
    return resultado;
  }

  //Obtener la lista de todos los tramites con una determinada etiqueta
  //--> Lo uso en CasoDeUsoTramiteConsultaPorEtiqueta [VERIFIQUEN!!]
  public List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta)
  {
    var resultado = new List<Tramite>();
    using var sr = new StreamReader(_nombreArch);
    while (!sr.EndOfStream)
    {
      var tramite = new Tramite();
      tramite.Id = int.Parse(sr.ReadLine() ?? "");
      tramite.ExpedienteId = int.Parse(sr.ReadLine() ?? "");
      tramite.Etiqueta = Enum.Parse<EtiquetaTramite>(sr.ReadLine() ?? "");
      tramite.Contenido = (sr.ReadLine() ?? "");
      tramite.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
      tramite.FechaUltMod = DateTime.Parse(sr.ReadLine() ?? "");
      tramite.IdUsuario = int.Parse(sr.ReadLine() ?? "");
      if (tramite.Etiqueta == etiqueta)
      {
        resultado.Add(tramite);
      }
    }
    sr.Close();
    return resultado;
  }

  //Lo uso al agregar un trámite a un expediente
  public void AgregarEtiq()
  {
    /*Asignar etiqueta a tramite --> mirar el ultimo tramite agregado
    al expediente
    llamamos a especificaciones y que nos retorne el estado cambiado o no*/
  }
}
