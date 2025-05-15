namespace CentroEventos.Aplicacion;
public class ValidadorReserva
{
    private readonly IRepositorioPersona _repositorioP;
    private readonly IRepositorioEventoDeportivo _repositorioED;
    private readonly IRepositorioReserva _repositorioR;
    public bool Validar(Reserva reserva, out string mensaje)
    {
        mensaje = "";
        if (_repositorioP.ObtenerPorID(reserva.PersonaId)==null) { 
            mensaje += "El ID de la persona no existe \n";
        }
        if(_repositorioED.ObtenerPorID(reserva.EventoDeportivoId) == null)
        {
            mensaje += "El ID del evento deportivo no existe \n";
            throw new EntidadNotFoundException()
        }
        if(_repositorioR.ObtenerPorPersonaYEvento(reserva.PersonaId, reserva.EventoDeportivoId) != null)
        {
            mensaje += "Ya existe una reserva para esta persona en este evento deportivo \n";
            throw new 
        }
        var reservas = _repositorioR.ObtenerPorEvento(reserva.EventoDeportivoId);
        var evento = _repositorioED.ObtenerPorID(reserva.EventoDeportivoId);
        if (reservas.Count>= evento.CupoMaximo) { 
            mensaje += "No hay cupo disponible para este evento deportivo \n";
        }

        return mensaje == "";


    }

}