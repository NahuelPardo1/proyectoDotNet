namespace CentroEventos.Aplicacion;

public interface IServicioAutorizacion{ // es provicional en esta entrega
    bool PoseeElPermiso(int IdUsuario, Permiso permiso);
}