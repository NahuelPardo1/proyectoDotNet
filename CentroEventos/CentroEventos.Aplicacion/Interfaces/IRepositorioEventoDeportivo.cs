namespace CentroEventos.Aplicacion;

public interface IRepositorioEventoDeportivo : IRepositorioBase<EventoDeportivo>
{
    List<EventoDeportivo> ObtenerPorPersona(int personaId);
}