namespace SGE.Aplicacion;
//ya estaría??
public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio tramiteRepositorio)
{
    ITramiteRepositorio _tramiteRepositorio;
    public CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio tramiteRepositorio)
    {
         _tramiteRepositorio = tramiteRepositorio;
    }
    /*Lista todos los trámites en el sistema que posean una etiqueta 
    específica (de los enumerativos EtiquetaTramite)... por ejemplo,
    todos los que tienen la etiqueta = PaseAEstudio*/
    public List<Tramite> Ejecutar()
    {
        /*lista todos los trámites que tienen una etiqueta --> */
        return tramiteRepositorio.ListarPorEtiqueta(EtiquetaTramite etiqueta);
    }
}