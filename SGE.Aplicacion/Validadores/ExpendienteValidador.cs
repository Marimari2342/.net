namespace SGE.Aplicacion;

public static class ExpendienteValidador
{
    
    public  ExpendienteValidador(){}

    public static bool Validar(Expediente expediente)
    {
        // Validar que la carátula del expediente no esté vacía
        // Validar que el Id de usuario en el expediente sea válido
     return (expediente.Caratula != null) && (expediente.IdUsuarioUltimaModificacion > 0);
    }
}
