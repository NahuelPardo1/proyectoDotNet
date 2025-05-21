using CentroEventos.Aplicacion;

namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; }= 0;
    public int EventoDeportivoId { get; set; }= 0;
    public DateTime FechaAltaReserva { get; set; } = DateTime.Now;
    public Estado EstadoReserva { get; set; }= Estado.Pendiente;
    public Reserva(int personaId, int eventoDeportivoId)
    {
        if(personaId <= 0)throw new ValidacionException("El ID de la persona no debe estar vacio");
        if(eventoDeportivoId <= 0) throw new ValidacionException("El id de Evento Deportivo no debe estar vacio");
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
    }
    public Reserva(int personaId, int eventoDeportivoId, Estado estadoReserva )
    {
        if (personaId <= 0) throw new ValidacionException("El ID de la persona no debe estar vacio");
        if (eventoDeportivoId <= 0) throw new ValidacionException("El id de Evento Deportivo no debe estar vacio");
        if (estadoReserva == null) throw new ValidacionException("El estado de la reserva no debe estar vacio");
        EstadoReserva = estadoReserva;
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
    }
    public Reserva(){ }
    public override string ToString()
    {
        return $"ID: {Id}\n" +
               $"A nombre de: {PersonaId}\n" +
               $"Incripto a el evento: {EventoDeportivoId}\n" +
               $"Fecha de alta: {FechaAltaReserva}\n"+
               $"Estado: {EstadoReserva}\n";
    }
    
}