namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    void agregarPersona(Persona persona);
    void modificarPersona(Persona persona);
    void eliminarPersona(int id);
    List<Persona> listarPersonas();
    Persona obtenerPorID(int id);
    Persona obtenerPorDNI(string dni);
    Persona obtenerPorEmail(string email);

}