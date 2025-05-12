namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona : IRepositorioBase<Persona>
{
    Persona obtenerPorDNI(string dni);
    Persona obtenerPorEmail(string email);
}