namespace SGE.Aplicacion;

public class TramiteValidador
{
     public bool Validar(Tramite tramite)
    {
        /* Validar que el contenido del tramite no esté vacío
         Validar que el Id de usuario del tramite sea válido*/
        return (tramite.Contenido != null) && (tramite.IdUsuarioUltimaModificacion > 0);
    }
}
