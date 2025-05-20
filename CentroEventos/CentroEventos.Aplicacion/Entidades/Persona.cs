namespace CentroEventos.Aplicacion;
public class Persona
{
    public int Id { get; set; } = 0;
    public string? Nombre { get; set; } = "";
    public string? DNI { get; set; } = "";
    public string? Apellido { get; set; } = "";
    public string? Email { get; set; } = "";
    public string? Telefono { get; set; } = "";
    public List<Permiso>? Permisos { get; set; } = new List<Permiso>();

    public Persona(string Nombre , string Apellido, string DNI, string Email, string Telefono) {
        if(string.IsNullOrWhiteSpace(Nombre)) throw new ValidacionException("El nombre no puede ser nulo ni estar vacio");
        if(string.IsNullOrWhiteSpace(DNI)) throw new ValidacionException("El DNI no puede ser nulo estar vacio");
        if(string.IsNullOrWhiteSpace(Email)) throw new ValidacionException("El mail no puede ser nulo ni estar vacio");
        if (Email != null && !EmailValido(Email)) throw new ValidacionException("El formato del mail no es válido.");
        if(DNIValido(DNI) == false) throw new ValidacionException("El formato del DNI no es válido.");
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.DNI = DNI;
        this.Email = Email;
        this.Telefono = Telefono;
    }

    public Persona() { }


    public static bool EmailValido(string email)
    {
        return email.Contains("@") && email.Contains(".") && email.IndexOf("@") < email.IndexOf(".");
    }

    public static bool DNIValido(string dni)
    {
        return dni.Length >=7 && dni.Length <=8 && int.TryParse(dni, out _);
    }
    public override string ToString()
    {
        return $"[{Id}] {Nombre} {Apellido} - DNI: {DNI} - Email: {Email} - Tel: {Telefono}";
    }
}