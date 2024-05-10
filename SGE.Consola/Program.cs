using SGE.Aplicacion;
using SGE.Repositorios;

//Menú
bool fin=false; 
string? option;
while( !fin ){ 
  Console.WriteLine("MENÚ:");
  Console.WriteLine("Ingrese 1 si quiere dar de ALTA un expediente.");
  Console.WriteLine("Ingrese 2 si quiere dar de BAJA un expediente.");
  Console.WriteLine("Ingrese 3 si quiere consultar un expediente por su ID junto con todos sus trámites.");
  Console.WriteLine("Ingrese 4 si quiere consultar todos los expedientes.");
  Console.WriteLine("Ingrese 5 si quiere MODIFICAR un expediente.");
  Console.WriteLine("Ingrese 6 si quiere dar de ALTA un trámite.");
  Console.WriteLine("Ingrese 7 si quiere dar de BAJA un trámite.");
  Console.WriteLine("Ingrese 8 si quiere consultar todos los trámites de una etiqueta específica.");
  Console.WriteLine("Ingrese 9 si quiere MODIFICAR un trámite.");
  Console.WriteLine("Ingrese 10 para cerrar el menú");
  Console.Write("Opción: "); option = Console.ReadLine();
  Console.Clear();
  switch (option)
  {
    case "1":
      AltaExpediente();
      break;
    case ("2"):
      BajaExpediente();
      break;
    case "3":
      ConsultaPorID();
      break;
    case "4":
      ConsultarTodosLosExpedientes();
      break;
    case "5":
      ModificarExpediente();
      break;
    case "6":
      AltaTramite();
      break;
    case "7":
      BajaTramite();
      break;
    case "8":
      ConsultaTramitesPorEtiqueta();
      break;
    case "9":
      ModificarTramite();
      break;
    case "10":
      fin=true;
      break;
    default:
      Console.WriteLine("Opción ingresada inválida.");
      break;
  }
}

void AltaExpediente(){
  try{ 

    Expediente e=new Expediente();
    Console.WriteLine("Ingrese los siguientes datos para poder dar de alta al expediente: ");
    Console.Write("Ingrese su id de usuario: "); string idUsuario=Console.ReadLine()?? "";
    Console.Write("Carátula del expediente: "); e.Caratula = Console.ReadLine();
    int idu=int.Parse(idUsuario);
    IExpedienteRepositorio expRepo= new ExpedienteRepositorioTXT();
    IServicioAutorizacion autoProvisoria= new ServicioAutorizacionProvisorio(); 
    var casoAlta= new CasoDeUsoExpedienteAlta(expRepo, autoProvisoria);
    casoAlta.Ejecutar(e,idu);
    
  }
  catch (ValidacionException msj){
    Console.WriteLine(msj.Message);
  }
  catch(Exception msj){
    Console.WriteLine(msj.Message);
  }
}

void BajaExpediente(){
  try{  
  Console.WriteLine("Ingrese los siguientes datos para poder dar de baja al expediente: ");
  Console.Write("Ingrese su id de usuario: "); string idUsuario=Console.ReadLine() ?? "";
  Console.Write("Ingrese id del expediente que desea dar de baja: "); string idExpediente= Console.ReadLine()??"";
  int idu=int.Parse(idUsuario);
  int ide=int.Parse(idExpediente);
  IExpedienteRepositorio expRepo= new ExpedienteRepositorioTXT();
  ITramiteRepositorio traRepo= new TramiteRepositorioTXT();
  IServicioAutorizacion autoProvisoria= new ServicioAutorizacionProvisorio(); 
  var casoBaja= new CasoDeUsoExpedienteBaja(autoProvisoria,expRepo,traRepo);
  casoBaja.Ejecutar(ide,idu);
  }
  catch(Exception e){
    Console.WriteLine(e.Message);
  }
}

void ConsultaPorID(){
 //No está completo porque falta la lista con todos los trámites del expediente consultado
  try{
    Console.Write("Ingrese el id del expediente que quiere consultar: "); int id= int.Parse(Console.ReadLine()?? "");
    IExpedienteRepositorio expedientes = new ExpedienteRepositorioTXT(); 
    var casoConsultaId = new CasoDeUsoExpedienteConsultaPorId(expedientes);
    Expediente E = casoConsultaId.Ejecutar(id);
    Console.WriteLine(E);
  }
  catch (RepositorioException e){
    Console.WriteLine(e.Message);
  }

}

void ConsultarTodosLosExpedientes(){
  IExpedienteRepositorio expedientes = new ExpedienteRepositorioTXT(); 
  var casoConsultaTodos = new CasoDeUsoExpedienteConsultaTodos(expedientes);
  List<Expediente>lista = casoConsultaTodos.Ejecutar();
  foreach(Expediente e in lista){
    Console.WriteLine(e);
  }
}

void ModificarExpediente () {
  try{  
    Console.WriteLine("Ingrese los siguientes datos para poder dar modificar el expediente: ");
    Console.Write("Ingrese su id de usuario: "); string idUsuario=Console.ReadLine()?? "";
    Expediente exp = new Expediente();
    Console.Write("Ingrese el id del expediente que desea modificar: "); exp.Id = int.Parse(Console.ReadLine()?? "");
    Console.Write("Ingrese la nueva caratula: "); exp.Caratula=Console.ReadLine();
    //El usuario puede modificar el estado?
    Console.Write("Ingrese el estado: ");exp.Estado = Enum.Parse<EstadoExpediente>(Console.ReadLine() ?? ""); 
    int idu=int.Parse(idUsuario);
    IExpedienteRepositorio expRepo= new ExpedienteRepositorioTXT();
    IServicioAutorizacion autoProvisoria= new ServicioAutorizacionProvisorio(); 
    var casoModificar= new CasoDeUsoExpedienteModificacion(expRepo, autoProvisoria);
    casoModificar.Ejecutar(exp,idu);
  }
  catch(Exception e){
    Console.WriteLine(e.Message);
  }
}

void AltaTramite(){
  try{
    Tramite t=new Tramite();
    Console.WriteLine("Ingrese los siguientes datos para poder dar de alta al trámite: ");
    Console.Write("Ingrese su id de usuario: "); string idUsuario=Console.ReadLine()?? "";
    Console.Write("Ingrese el id del expediente al que pertenece: "); t.ExpedienteId = int.Parse(Console.ReadLine()?? "");
    Console.WriteLine("Ingrese el contenido del trámite: "); t.Contenido = Console.ReadLine();
    //La etiqueta es definida por el usuario o de acuerdo a la etiqueta del último tramite del expediente al que pertenece?
    //Console.WriteLine("Ingrese la etiqueta del trámite(EscritoPresentado,PaseAEstudio,Despacho,Resolucion,Notificacion,PaseAlArchivo): ");
    t.Etiqueta = Enum.Parse<EtiquetaTramite>(Console.ReadLine() ?? "");
    int idu=int.Parse(idUsuario); 
    ITramiteRepositorio traRepo= new TramiteRepositorioTXT();
    IEspecificacionCambioEstado especificacion = new EspecificacionCambioEstado();
    ServicioActualizacionEstado sae = new ServicioActualizacionEstado(especificacion);
    IServicioAutorizacion autoProvisoria= new ServicioAutorizacionProvisorio(); 
    IExpedienteRepositorio expRepo= new ExpedienteRepositorioTXT();
    var casoAlta= new CasoDeUsoTramiteAlta(traRepo,expRepo, autoProvisoria,sae);
    casoAlta.Ejecutar(t,idu);
  }
  catch (ValidacionException msj){
    Console.WriteLine(msj.Message);
  }
  catch(Exception msj){
    Console.WriteLine(msj.Message);
  }
}

void BajaTramite() {
  try{
    Tramite t=new Tramite();
    Console.WriteLine("Ingrese los siguientes datos para poder dar de baja un trámite: ");
    Console.Write("Ingrese su id de usuario: "); string idUsuario=Console.ReadLine()?? "";
    Console.Write("Ingrese el id del tramite que desea dar de baja: "); t.ExpedienteId = int.Parse(Console.ReadLine()?? "");
    int idu=int.Parse(idUsuario);
    ITramiteRepositorio traRepo= new TramiteRepositorioTXT();
    IEspecificacionCambioEstado especificacion = new EspecificacionCambioEstado();
    ServicioActualizacionEstado sae = new ServicioActualizacionEstado(especificacion);
    IServicioAutorizacion autoProvisoria= new ServicioAutorizacionProvisorio(); 
    IExpedienteRepositorio expRepo= new ExpedienteRepositorioTXT();
    var casoBaja= new CasoDeUsoTramiteBaja(traRepo,expRepo, autoProvisoria,sae);
    casoBaja.Ejecutar(t,idu);
    Console.WriteLine($"Se eliminó el tramite con id {t.ExpedienteId}");
  }
  catch (ValidacionException msj){
    Console.WriteLine(msj.Message);
  }
  catch(Exception msj){
    Console.WriteLine(msj.Message);
  }
}

void ConsultaTramitesPorEtiqueta(){
 try{
    Console.WriteLine("Ingrese la etiqueta para listar todos los tramites con la misma: ");
    EtiquetaTramite etiqueta = Enum.Parse<EtiquetaTramite>(Console.ReadLine() ?? "");
    ITramiteRepositorio tramiteRepo = new TramiteRepositorioTXT();
    var casoConsultarEtiqueta = new CasoDeUsoTramiteConsultaPorEtiqueta(tramiteRepo);
    List<Tramite> L= casoConsultarEtiqueta.Ejecutar(etiqueta);
    foreach(Tramite t in L){
      Console.WriteLine(t);
    }
 }
 catch (RepositorioException e){
  Console.WriteLine(e.Message);
 }
 catch (Exception e){
   Console.WriteLine(e.Message);
 }

}

void ModificarTramite(){
  try{
    Tramite t=new Tramite();
    Console.WriteLine("Ingrese los siguientes datos para poder modificar un trámite: ");
    Console.Write("Ingrese su id de usuario: "); string idUsuario=Console.ReadLine()?? "";
    Console.Write("Ingrese el id del tramite que desea modificar: "); t.Id = int.Parse(Console.ReadLine()?? "");
    //El usuario puede modificar la etiqueta?
    Console.Write("Nueva etiqueta: "); t.Etiqueta = Enum.Parse<EtiquetaTramite>(Console.ReadLine() ?? "");
    Console.Write("Nuevo contenido: "); t.Contenido = Console.ReadLine();
    int idu=int.Parse(idUsuario);
    ITramiteRepositorio traRepo= new TramiteRepositorioTXT();
    IEspecificacionCambioEstado especificacion = new EspecificacionCambioEstado();
    ServicioActualizacionEstado sae = new ServicioActualizacionEstado(especificacion);
    IServicioAutorizacion autoProvisoria= new ServicioAutorizacionProvisorio(); 
    IExpedienteRepositorio expRepo= new ExpedienteRepositorioTXT();
    var casoModificar= new CasoDeUsoTramiteModificacion(traRepo,expRepo, autoProvisoria,sae);
    casoModificar.Ejecutar(t,idu);
    Console.WriteLine($"Se modificó el tramite con id {t.Id}");
  }
  catch (ValidacionException msj){
    Console.WriteLine(msj.Message);
  }
  catch(Exception msj){
    Console.WriteLine(msj.Message);
  }  
}