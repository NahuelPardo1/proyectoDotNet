namespace CentroEventos.Aplicacion;

public class ServicioAutorizacionProvisorio: IServicioAutorizacion
{
	public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
	{
		return IdUsuario == 1;
	}
}
