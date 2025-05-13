namespace CentroEventos.Aplicacion;
public class EventoDeportivo
{
    public int Id { get; set; } // debe ser autoIncrementada por el repositorio
    public string Nombre { get; set; }
    public string Descripcion {get;set;}
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras{get;set;}
    public int CupoMaximo {get;set;}
    public int ResponsbleID {get;set;}

    public override string ToString()
    {
        return $"ID:{Id}\n"+ 
               $"Nombre:{Nombre}\n" + 
               $"Descripcion:{Descripcion}\n" +
               $"FechaHoraInicio:{FechaHoraInicio}\n" +
               $"DuracionHoras:{DuracionHoras}\n" +
               $"CupoMaximo:{CupoMaximo}\n" +
               $"ResponsbleID:{ResponsbleID}\n";
    }
}