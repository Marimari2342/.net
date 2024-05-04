namespace SGE.Repositorios;
using SGE.Aplicacion;

public class ExpedienteRepositorioTXT : IExpedienteRepositorio
{
    
    readonly string _nombreArch; //No deberíamos hacer readonly string _nombreArch= "expedientes.txt"? 
    //Porque el nombre del archivo _nombreArch se declara como un campo de solo lectura y no se inicializa en ningún lugar
    static int cantE=0; //???

    
    public void Agregar(Expediente e){
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(e.Id=cantE++);  // ??? 
        sw.WriteLine(e.Caratula);
        sw.WriteLine(e.FechaCreacion);
        sw.WriteLine(e.UltimaModificacion);
        sw.WriteLine(e.IdUsuarioUltimaModificacion);
        sw.WriteLine(e.Estado);
    }

    public Expediente ObtenerPorId(int id){
        Expediente? resultado = null;
        //Codigo...
    
        if( resultado == null ){
            throw new RepositorioException($"No existe un expediente con id: {id}");
        }
        return resultado;   
    }

    public void Eliminar(int id){
        bool ok=false;
        //Codigo
        if(!ok){
            throw new RepositorioException($"El expediente con el id={id} no existe");
        }

    }

    public void Modificar(Expediente e,int id){
        bool ok=false;
        //Codigo
        if(!ok){
            throw new RepositorioException($"El expediente con el id={id} no existe");
        }
    }

}
