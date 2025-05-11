namespace CentroEventos.Aplicacion

public class ValidadorPersona
{
    private readonly IRepositorioPersona p;

    public ValidadorPersona(IRepositorioPersona p)
    {
        this.p = p;
    }

    public bool Validador(Persona persona, out string mensaje)
    {
        mensaje = "";
        if (string.isNullOrEmptySpace(persona.Nombre))
        {
            mensaje = "El nombre no puede estar vacio";
        }

        if (string.isNullOrEmptySpace(persona.Apellido))
        {
            mensaje = "El apellido no puede estar vacio";
        }

        if (string.isNullOrEmptySpace(persona.DNI))
        {
            mensaje= "El DNI no puede estar vacio";
        }

        if (string.isNullOrEmptySpace(persona.Email))
        {
            mensaje = "El email no puede estar vacio";
        }

        if (p.obtenerPorDNI(persona.DNI) != null)
        {
            mensaje = "El DNI ya existe";
        }

        if (p.obtenerPorEmail(persona.Email)!= null)
        {
            mensaje = "El email ya existe";
        }

        return mensaje == "";
    }
}