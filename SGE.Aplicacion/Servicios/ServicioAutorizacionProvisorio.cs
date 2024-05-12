namespace SGE.Aplicacion;
//Servicio de autorización provisional para la primer entrega
public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario)
    {
        bool aux;
        if (IdUsuario != 1) {
            //Es necesario poner aux = false? o con la excepción es suficiente.
            throw new AutorizacionException("El usuario no posee los permisos necesarios");
        }
        else {
            Console.WriteLine("Ingreso aceptado");
            aux = true;
            }
    }

}
