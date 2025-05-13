namespace CentroEventos.Aplicacion;
public class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string DNI { get; set; } 
    public string Apellido { get; set; } 
    public string Email { get; set; }
    public string Telefono { get; set; }

    public override string ToString()
    {
        return $"[{Id}] {Nombre} {Apellido} - DNI: {DNI} - Email: {Email} - Tel: {Telefono}";
    }
}