namespace CentroEventos.Aplicacion;

public ListarEventosConCupoDisponibleUseCase{
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;
    private readonly IRepositorioReserva _repositorioReserva;

    public ListarEventosConCupoDisponibleUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioReserva repositorioReserva)
    {
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
        _repositorioReserva = repositorioReserva;
    }

public List<EventoDeportivo> Ejecutar() { 
    List<EventoDeportivo> eventosConCupo = new List<EventoDeportivo>();
    List<EventoDeportivo> eventos = _repositorioEventoDeportivo.ObtenerTodos();
    foreach (EventoDeportivo evento in eventos)
    {
        List<Reserva> reservas = _repositorioReserva.ObtenerPorEvento(evento.Id);
        if (evento.FechaHoraInicio > DateTime.Now && reservas.Count < evento.CupoMaximo)
        {
            eventosConCupo.Add(evento);
        }
    }
    return eventosConCupo;
}

}