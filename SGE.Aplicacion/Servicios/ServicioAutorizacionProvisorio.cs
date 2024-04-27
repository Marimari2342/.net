﻿namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {
        // Usuario con Id 1 tiene acceso a todos los permisos
        return IdUsuario == 1;
    }
}
