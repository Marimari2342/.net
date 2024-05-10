namespace SGE.Repositorios;
using SGE.Aplicacion;

public class ExpedienteRepositorioTXT : IExpedienteRepositorio
{
    
    readonly string _nombreArch; //No deberíamos hacer readonly string _nombreArch= "expedientes.txt"? 
    //Porque el nombre del archivo _nombreArch se declara como un campo de solo lectura y no se inicializa en ningún lugar



    //Retorna id para el expediente que se quiere dar de alta
    public int ObtenerSiguienteId (){  
        int id=0;
        if(File.Exists(_nombreArch)) { 
          List<Expediente> list = ObtenerTodos();
          foreach (Expediente exp in list){
            id=exp.Id;
          }
        }
        return ++id;
    }

    //Método usado después de haber realizado una eliminacion o una modificación para guardar los cambios
    private void GuardarCambios(List<Expediente> list){
      File.Delete(_nombreArch);
      foreach(Expediente exp in list){
        Agregar(exp);
      }
    }


    public void Agregar(Expediente e)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(e.Id);  
        sw.WriteLine(e.Caratula);
        sw.WriteLine(e.FechaCreacion);
        sw.WriteLine(e.UltimaModificacion);
        sw.WriteLine(e.IdUsuarioUltimaModificacion);
        sw.WriteLine(e.Estado);
        sw.Close();
    }
    
    //Lo uso en caso de uso expediente BAJA
    public void Eliminar(int id){
        bool ok=false;
        List<Expediente> lista=ObtenerTodos();
        int i=0;
        while( (i<lista.Count) && (!ok) ){
            if(lista[i].Id == id){
                ok=true;
                lista.RemoveAt(i);
                GuardarCambios(lista);
            }
            i++;
        }
        if(!ok){
            throw new RepositorioException($"El expediente que quiere dar de baja no existe");
        }
    }

    //Obtener un expediente por su Id
    //--> Lo uso en CasoDeUsoExpedienteConsultaPorId [VERIFIQUEN!!]
    public Expediente ObtenerPorId(int id)
    {
        Expediente? resultado = null;
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)&&(expediente.Id != id)
        {
            var expediente = new Expediente();
            expediente.Id = int.Parse(sr.ReadLine() ?? "");
            expediente.Caratula = sr.ReadLine() ?? "";
            expediente.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
            expediente.UltimaModificacion = DateTime.Parse(sr.ReadLine() ?? "");
            expediente.IdUsuarioUltimaModificacion = int.Parse(sr.ReadLine() ?? "");
            expediente.Estado = sr.ReadLine() ?? "";  
            if (expediente.Id != id)
            {
                resultado = expediente;
            }
        }
        sr.Close();
        if (resultado == null)
        {
            throw new RepositorioException($"No existe un expediente con id: {id}");
        }
        return resultado;
    }

    //Lo uso en caso de uso expediente MODIFICACION
    public void Modificar(Expediente e){
        bool ok=false;
        List<Expediente> lista=ObtenerTodos();
        int i=0;
        while( (i<lista.Count) && !ok ){
            if(lista[i].Id == e.Id){
                ok=true;
                e.FechaCreacion = lista[i].FechaCreacion;
                lista[i]=e;
                GuardarCambios(lista);
            }
            i++;
        }
        if(!ok){
            throw new RepositorioException($"El expediente con el id pedido no existe");
        }
    }

    //Obtener la lista de todos los expedientes (sin sus Tramites)
    //--> Lo uso en CasoDeUsoExpedienteConsultaTodos [VERIFIQUEN!!]
    public List<Expediente> ObtenerTodos()
    {
        var resultado = new List<Expediente>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var expediente = new Expediente();
            expediente.Id = int.Parse(sr.ReadLine() ?? "");
            expediente.Caratula = sr.ReadLine() ?? "";
            expediente.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
            expediente.UltimaModificacion = DateTime.Parse(sr.ReadLine() ?? "");
            expediente.IdUsuarioUltimaModificacion = int.Parse(sr.ReadLine() ?? "");
            expediente.Estado = sr.ReadLine() ?? "";
            resultado.Add(expediente);
        }
        sr.Close();
        return resultado;
    }
}
