namespace SGE.Repositorios;
using SGE.Aplicacion;

public class TramiteRepositorioTXT : ITramiteRepositorio
{
  readonly string _nombreArch = "tramites.txt";

 public List<Tramite> ListarPorIdExpediente(int idExpediente)
    {
        // Aquí implementa la lógica para listar los trámites por el ID del expediente desde el archivo de texto
        var resultado = new List<Tramite>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream){
            var tramite = new Tramite();
            tramite.Id = int.Parse(sr.ReadLine() ?? "");
            tramite.ExpedienteId =  int.Parse(sr.ReadLine() ?? "");
            if(tramite.ExpedienteId == idExpediente){ 
              tramite.Etiqueta = Enum.Parse<EtiquetaTramite>(sr.ReadLine() ?? "");
              tramite.Contenido= sr.ReadLine();
              tramite.FechaCreacion=DateTime.Parse(sr.ReadLine() ?? "");
              tramite.UltimaModificacion= DateTime.Parse(sr.ReadLine()?? "");
              tramite.IdUsuarioUltimaModificacion= int.Parse(sr.ReadLine() ?? "");
              resultado.Add(tramite);
            }
            else{
                for(int i=0; i<5; i++){ 
                    sr.ReadLine();
                }
            }

        }
        sr.Close();
        return resultado; 
    }

   public Tramite ObtenerPorId(int id)
    {
        // Aquí implementa la lógica para obtener el trámite por su ID desde el archivo de texto
        Tramite resultado = new Tramite();
        resultado.Id = -1;
        using var sr = new StreamReader(_nombreArch,true);
        while ((!sr.EndOfStream) && (resultado.Id == -1)){
            var tramite = new Tramite();
            tramite.Id = int.Parse(sr.ReadLine() ?? "");
            if(tramite.Id == id)
            { 
              tramite.ExpedienteId = int.Parse(sr.ReadLine() ?? "");
              tramite.Etiqueta=Enum.Parse<EtiquetaTramite>(sr.ReadLine()?? "");
              tramite.Contenido= sr.ReadLine()?? "";
              tramite.FechaCreacion=DateTime.Parse(sr.ReadLine()?? "00/00/0000");  
              tramite.UltimaModificacion= DateTime.Parse(sr.ReadLine() ?? "00/00/0000");
              tramite.IdUsuarioUltimaModificacion= int.Parse(sr.ReadLine()?? "");
              resultado=tramite;
            }
            else{
                for(int i=0; i<6; i++){ 
                    sr.ReadLine();
                }
            }
        }
        sr.Close(); 
        return resultado;  
    }

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

  //Método usado después de haber realizado una eliminacion o una modificación
  private void GuardarCambios(List<Tramite> list)
  {
    File.Delete(_nombreArch);
    foreach (Tramite t in list)
    {
      Agregar(t);
    }
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
    // Desde acá llamo al método ActualizarEstado() o desde donde??
  }

  //Caso de uso trámite BAJA
    //Caso de uso trámite MODIFICACIÓN
    public void Modificar(Tramite t, out bool ok){
        ok=false;
        List<Tramite> lista=ListarTramites();
        int i=0;
        while( (i<lista.Count) && !ok ){
            if(lista[i].Id == t.Id){
                ok=true;
                t.ExpedienteId = lista[i].ExpedienteId;
                t.FechaCreacion = lista[i].FechaCreacion;
                lista[i]=t;
                GuardarCambios(lista);
            }
            i++;
        }
    // Desde acá llamo al método ActualizarEstado() o desde donde??
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
  public EtiquetaTramite AgregarEtiq()
  {
    List<Tramite> lista = ListarTramites();
    Tramite ultimo = lista[lista.Count];
    // Desde acá llamo al método ActualizarEstado() o desde donde??
    return (EtiquetaTramite)(((int)ultimo.etiqueta + 1));//Esto es así????
  }

  //Caso de uso trámite MODIFICACIÓN
    public void Modificar(Tramite t, out bool ok){
        ok=false;
        List<Tramite> lista=ListarTramites();
        int i=0;
        while( (i<lista.Count) && !ok ){
            if(lista[i].Id == t.Id){
                ok=true;
                t.ExpedienteId = lista[i].ExpedienteId;
                t.FechaCreacion = lista[i].FechaCreacion;
                lista[i]=t;
                GuardarCambios(lista);
            }
            i++;
        }

    }
    //Usado en el CasoDeUsoExpedienteBaja
    public void EliminarTramitesPorIdExpediente(int idExpediente){
         List<Tramite> lista = ListarTramites();
         for(int i=0; i< lista.Count;i++){
            if(lista[i].ExpedienteId == idExpediente){
                lista.RemoveAt(i);
            }
         }
         GuardarCambios(lista);
    }


  //Falta agregarlo a cuando modifican, eliminan y agregan un trámite... 
  //FIJENSE
  private void ActualizarEstado()
  {
    List<Tramite> lista = ListarTramites();

    if (lista.Any())
    {
      Tramite ultimoTramite = lista[lista.Count - 1];

      switch (ultimoTramite.Etiqueta)
      {
        case EtiquetaTramite.Resolucion:
          Estado = EstadoExpediente.ConResolucion;
          break;
        case EtiquetaTramite.PaseAEstudio:
          Estado = EstadoExpediente.ParaResolver;
          break;
        case EtiquetaTramite.PaseAlArchivo:
          Estado = EstadoExpediente.Finalizado;
          break;
        default:
          // Si el último trámite no es uno que cambie el estado, mantener el estado actual
          break;
      }
    }
    else
    {
      // Si no hay trámites, el estado es RecienIniciado
      Estado = EstadoExpediente.RecienIniciado;

    }
  }
}
