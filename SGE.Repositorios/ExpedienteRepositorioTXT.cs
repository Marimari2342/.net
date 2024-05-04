namespace SGE.Repositorios;
using SGE.Aplicacion;

public class ExpedienteRepositorioTXT : IExpedienteRepositorio
{

    readonly string _nombreArch;
    static int cantE = 0; //???


    public void Agregar(Expediente e)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(e.Id = cantE++);  // ??? 
        sw.WriteLine(e.Caratula);
        sw.WriteLine(e.FechaCreacion);
        sw.WriteLine(e.UltimaModificacion);
        sw.WriteLine(e.IdUsuarioUltimaModificacion);
        sw.WriteLine(e.Estado);
    }

    public Expediente ObtenerPorId(int id)
    {
        Expediente? resultado = null;
        //Codigo...

        if (resultado == null)
        {
            throw new RepositorioException($"No existe un expediente con id: {id}");
        }
        return resultado;
    }

    public void Eliminar(int id)
    {
        bool ok = false;
        //Codigo
        if (!ok)
        {
            throw new RepositorioException($"El expediente con el id={id} no existe");
        }

    }

    public void Modificar(Expediente e, int id)
    {
        bool ok = false;
        //Codigo
        if (!ok)
        {
            throw new RepositorioException($"El expediente con el id={id} no existe");
        }
    }

    //Obtener la lista de todos los expedientes (sin sus Tramites)
    //--> Lo uso en CasoDeUsoExpedienteConsultaTodos 
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
        return resultado;
    }

}
