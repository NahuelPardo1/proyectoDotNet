namespace CentroEventos.Aplicacion;
public class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string DNI { get; set; } = string.Empty;
    public string Apellido { get; set; } string.Empty;
    public string Email { get; set; } string.Empty;

    public override string ToString()
    {
        return $"[{Id}] {Nombre} {Apellido} - DNI: {DNI} - Email: {Email} - Tel: {Telefono}";
    }
}