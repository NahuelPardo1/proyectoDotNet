namespace CentroEventos.Aplicacion;
public class ValidadorReserva
{
    private readonly IRepositorioPersona _repositorioP;
    private readonly IRepositorioEventoDeportivo _repositorioED;
    private readonly IRepositorioReserva _repositorioR;
    public ValidadorReserva(IRepositorioPersona repositorioP, IRepositorioEventoDeportivo repositorioED, IRepositorioReserva repositorioR)
    {
        _repositorioP = repositorioP;
        _repositorioED = repositorioED;
        _repositorioR = repositorioR;
    }
    public bool Validar(Reserva reserva, out string mensaje)
    {
        mensaje = "";
        if (_repositorioP.ObtenerPorID(reserva.PersonaId)==null) { 
            mensaje += "El ID de la persona no existe \n";
        }
        if(_repositorioED.ObtenerPorID(reserva.EventoDeportivoId) == null)
        {
            mensaje += "El ID del evento deportivo no existe \n";
        }
        if(_repositorioR.ObtenerPorPersonaYEvento(reserva.PersonaId, reserva.EventoDeportivoId) != null)
        {
            mensaje += "Ya existe una reserva para esta persona en este evento deportivo \n";
        }
        var reservas = _repositorioR.ObtenerPorEvento(reserva.EventoDeportivoId);
        var evento = _repositorioED.ObtenerPorID(reserva.EventoDeportivoId);
        if (reservas.Count>= evento.CupoMaximo) { 
            mensaje += "No hay cupo disponible para este evento deportivo \n";
        }

        return mensaje == "";


    }

}