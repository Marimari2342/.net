namespace SGE.Aplicacion;

public class ExpendienteValidador
{
    public bool Validar(Expediente expediente)
    {
        // Validar que la carátula del expediente no esté vacía
        // Validar que el Id de usuario en el expediente sea válido
            return (expediente.Caratula != null) && (expediente.IdUsuarioUltimaModificacion > 0);
    }
}
