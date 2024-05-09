namespace SGE.Aplicacion;
//Servicio de autorización provisional para la primer entrega
public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    //try {
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {

        // Usuario con Id 1 tiene acceso a todos los permisos
        return IdUsuario == 1;

        tienePermiso(IdUsuario);
    }
    
    /*}
    catch (AutorizacionException e)
    {
        Console.WriteLine(e.Message);
    }
    */
}
