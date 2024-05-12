namespace SGE.Aplicacion;

//Servicio de autorización provisional para la primer entrega
public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario)
    {
    bool aux;
    if (IdUsuario != 1) {
        // Lanzar la excepción con el mensaje adecuado
        throw new AutorizacionException("El usuario no posee los permisos necesarios");
    }
    else {
        Console.WriteLine("Ingreso aceptado");
        aux = true;
    }
    return aux; // Asegúrate de devolver el valor auxiliar en todos los casos
    }
}