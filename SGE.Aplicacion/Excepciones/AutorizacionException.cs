namespace SGE.Aplicacion;

public class AutorizacionException : Exception

//Es lanzada cuando un usuario intenta realizar una operacion para la cual no tiene los permisos necesarios
{
    public AutorizacionException(string message) : base(message) { }
}
