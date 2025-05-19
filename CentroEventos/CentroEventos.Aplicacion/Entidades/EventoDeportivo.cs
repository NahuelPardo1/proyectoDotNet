namespace CentroEventos.Aplicacion;
public class EventoDeportivo
{
    public int Id { get; set; } // debe ser autoIncrementada por el repositorio
    public string? Nombre { get; set; }
    public string? Descripcion {get;set;}
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras{get;set;}
    public int CupoMaximo {get;set;}
    public int ResponsbleID {get;set;}

    public override string ToString()
    {
        return $"{Id}|{Nombre}|{Descripcion}|{FechaHoraInicio}|{DuracionHoras}|{CupoMaximo}|{ResponsbleID}";
    }
}