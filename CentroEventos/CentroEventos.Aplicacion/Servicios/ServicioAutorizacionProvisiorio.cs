using CentroEventos.Aplicacion;
namespace CentroEventos.Aplicacion.Servicios
{
	public class ServicioAutorizacionProvisiorio: IServicioAutorizacion
	{
		public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
		{
			return IdUsuario == 1;
		}
	}
}
