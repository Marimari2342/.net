namespace SGE.Aplicacion;

public class TramiteValidador
{
     public bool Validar(Tramite tramite)
    {
        // Validar que el contenido no esté vacío
        if (string.IsNullOrEmpty(tramite.Contenido))
            return false;

        // Validar que el Id de usuario sea válido
        if (tramite.IdUsuarioUltimaModificacion <= 0)
            return false;

        return true;
    }
}
