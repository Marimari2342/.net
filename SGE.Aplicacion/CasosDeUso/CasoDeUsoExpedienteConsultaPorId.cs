namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio)
{
    /*permite la consulta de un expediente junto con todos sus 
    trámites, utilizando el Id del expediente como referencia
    (devolverá tipo una lista del expediente y sus trámites --> un ToString ¿¿??)*/
    public Expediente ConsultarConTramites(int idExpediente)
    {
        // Obtener expediente
        Expediente expediente = expedienteRepositorio.ObtenerPorId(idExpediente);

        // Obtener trámites asociados al expediente
        //IEnumerable;
    }
}
