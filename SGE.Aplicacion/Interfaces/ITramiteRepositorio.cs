namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    Tramite ObtenerPorId(int id);
    void Agregar(Tramite tramite);
    void Eliminar(int id);
    void Modificar(Tramite tramite);
    // Otros métodos necesarios
}
