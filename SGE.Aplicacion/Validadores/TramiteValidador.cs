namespace SGE.Aplicacion;

public class TramiteValidador
{
     public bool Validar(Tramite tramite)
    {
        // Validar que el contenido del tramite no esté vacío
        if (tramite.Contenido == null)
            return false;

        // Validar que el Id de usuario del tramite sea válido
        if (tramite.IdUsuarioUltimaModificacion <= 0)
            return false;

        return true;
    }
}
