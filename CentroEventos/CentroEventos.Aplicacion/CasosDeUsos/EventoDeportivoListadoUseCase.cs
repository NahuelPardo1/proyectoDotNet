namespace CentroEventos.Aplicacion;


public class EventoDeportivoListadoUseCase
{
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;

    public EventoDeportivoListadoUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo)
    {
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public List<EventoDeportivo> Ejecutar()
    {
        List<EventoDeportivo> listaEventos = _repositorioEventoDeportivo.Listar();
        List<EventoDeportivo> listaEventosFiltrada = new List<EventoDeportivo>();
        foreach (EventoDeportivo evento in listaEventos)
        {
            if (evento.FechaHoraInicio > DateTime.Now)
            {
                listaEventosFiltrada.Add(evento);
            }
        }
        return listaEventosFiltrada;
    }
}