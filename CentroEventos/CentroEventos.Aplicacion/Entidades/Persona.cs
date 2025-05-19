namespace CentroEventos.Aplicacion;
public class Persona
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? DNI { get; set; } 
    public string? Apellido { get; set; } 
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public List<Permiso>? Permisos { get; set; } = new List<Permiso>();

    public Persona(string Nombre , string Apellido, string DNI, string Email, string Telefono) { 
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.DNI = DNI;
        this.Email = Email;
        this.Telefono = Telefono;
    }

    public Persona() { }

    public override string ToString()
    {
        return $"[{Id}] {Nombre} {Apellido} - DNI: {DNI} - Email: {Email} - Tel: {Telefono}";
    }
}