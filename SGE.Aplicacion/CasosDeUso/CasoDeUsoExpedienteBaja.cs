namespace SGE.Aplicacion;

/*ExpedienteBaja: Puede realizar bajas de expedientes
Necesito -->    El ID del expediente
                El ID del usuario que lo quiere dar de baja
                Verificar que el usuario tenga el permiso para esto
                Verificar que el ID del expediente sea válido
                Anotar la fecha de eliminacion (?) creo que no....
                Eliminar expediente
Se debe garantizar que para las operaciones de alta, baja y modificación se verifique la autorización del
usuario antes de proceder. Por lo tanto, el método Ejecutar de estos casos de uso deberá recibir también el
Id del usuario como parámetro.*/

public class CasoDeUsoExpedienteBaja
{
    private readonly IExpedienteRepositorio _expedienteRepositorio;

    public CasoDeUsoExpedienteBaja(IExpedienteRepositorio expedienteRepositorio)
    {
        _expedienteRepositorio = expedienteRepositorio;
    }

    public void Ejecutar(int idExpediente, int idUsuario)
    {
        // Verificar que el ID del expediente sea válido
        if (expedienteRepositorio.ObtenerPorId(idExpediente)==null)
        {
            throw new RepositorioException("El expediente buscado no existe")
        }

        // Verificar permisos
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja))
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar esta operación.");
        }

        // Eliminar expediente en el repositorio
        _expedienteRepositorio.Eliminar(expediente);
    }
}