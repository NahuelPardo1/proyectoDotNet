namespace CentroEventos.Aplicacion;

public interface IRepositorioBase<T>
{
    void Agregar(T entidad);
    void Modificar(int id,T entidad);
    void Eliminar(int id);
    List<T>? Listar();
    T? ObtenerPorID(int id);
    
}