namespace SGE.Aplicacion;

public class ExpendienteValidador
{
    public bool Validar(Expediente expediente)
    {
        // Validar que la carátula del expediente no esté vacía
        if (expediente.Caratula == null)
            return false;
            
        // Validar que el Id de usuario en el expediente sea válido
        if (expediente.IdUsuarioUltimaModificacion <= 0)
            return false;

        return true;
    }
}
