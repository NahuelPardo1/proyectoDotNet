namespace CentroEventos.Aplicacion
{
    public class ListarAsistenciaAEventoUseCase
    {
        private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;
        private readonly IRepositorioPersona _repositorioPersona;
        private readonly IRepositorioReserva _repositorioReserva;
        public ListarAsistenciaAEventoUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioPersona repositorioPersona, IRepositorioReserva repositorioReserva)
        {
            _repositorioEventoDeportivo = repositorioEventoDeportivo;
            _repositorioPersona = repositorioPersona;
            _repositorioReserva = repositorioReserva;
        }

        public List<Persona> Ejecutar(EventoDeportivo e)
        {
            List<Persona> asistentes = new List<Persona>();
            List<Reserva> reservas = _repositorioReserva.ObtenerPorEvento(e.Id);
            foreach (Reserva reserva in reservas)
            {
                if (reserva.EstadoReserva == Estado.Presente)
                {
                    Persona persona = _repositorioPersona.ObtenerPorID(reserva.PersonaId);
                    if (persona != null)
                    {
                        asistentes.Add(persona);
                    }
                }

            }
            return asistentes;
        }
    }
}