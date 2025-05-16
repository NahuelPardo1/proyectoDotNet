namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; }
    public Estado EstadoReserva { get; set; }
    
    public override string ToString()
    {
        return $"ID:{Id}\n" +
               $"Nombre:{PersonaId}\n" +
               $"Descripcion:{EventoDeportivoId}\n" +
               $"FechaHoraInicio:{FechaAltaReserva}\n" +
               $"DuracionHoras:{FechaAltaReserva}\n" +
               $"CupoMaximo:{EstadoReserva}\n";
    }
    
}