namespace SGE.Aplicacion;

public class RepositorioException : Exception
//Es lanzada cuando la entidad que se intenta eliminar, modificar o acceder no existe
{
    public RepositorioException(string message) : base(message) { }
}
