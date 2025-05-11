namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int Id { get; set; };
    public int PersonalId { get; set; };
    public int EventoDeportivoId { get; set; };
    public DateTime FechaAltaReserva { get; set; };
    public enun EstadoReserva { get; set; };
    
    public Reserva()
    {
        PersonalId=0;
        EventoDeportivoId=0;
        FechaAltaReserva=0;
        EstadoReserva=0;
    }

    public override string ToString()
    {
        return $"ID:{ID}\n" +
               $"Nombre:{PersonalId}\n" +
               $"Descripcion:{EventoDeportivoId}\n" +
               $"FechaHoraInicio:{FechaHoraInicio}\n" +
               $"DuracionHoras:{FechaAltaReserva}\n" +
               $"CupoMaximo:{EstadoReserva}\n";
    }
    
}