using CentroEvento.Aplicacion;

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

        public List<Persona> Ejecutar(int id)
        {
            // 1. Verificar existencia del evento
            
            if(_repositorioEventoDeportivo.ObtenerPorID(id) == null)
            {
                throw new EntidadNotFoundException("El evento no existe");
            }

            List<Persona> asistentes = new List<Persona>();
            List<Reserva> reservas = _repositorioReserva.ObtenerPorEvento(id);
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