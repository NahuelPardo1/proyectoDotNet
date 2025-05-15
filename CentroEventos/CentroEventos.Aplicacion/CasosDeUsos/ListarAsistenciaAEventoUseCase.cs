namespace CentroEventos.Aplicacion
{
    public class ListarAsistenciaAEventoUseCase
    {
        private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;
        private readonly IRepositorioPersona _repositorioPersona;
        public ListarAsistenciaAEventoUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioPersona repositorioPersona)
        {
            _repositorioEventoDeportivo = repositorioEventoDeportivo;
            _repositorioPersona = repositorioPersona;
        }

        public List<Persona> Ejecutar(EventoDeportivo e) {
            List<Persona> asistentes = new List<Persona>();
            List<Reserva> reservas = _repositorioEventoDeportivo.ObtenerReservasPorEvento(e.Id);
            foreach (Reserva reserva in reservas)
            {
                if (reserva.EstadoReserva == Estado.Presente) {
                    Persona persona = _repositorioPersona.ObtenerPorId(reserva.PersonaId);
                    if (persona != null)
                    {
                        asistentes.Add(persona);
                    }
                }
                
            }
            return asistentes;
        }