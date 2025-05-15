namespace CentroEventos.Aplicacion;

public class ValidadorPersona
{
    private readonly IRepositorioPersona _repositorio;

    public ValidadorPersona(IRepositorioPersona p)
    {
        this._repositorio = p;
    }

    public bool Validador(Persona persona, out string mensaje)
    {
        mensaje = "";
        if (string.IsNullOrWhiteSpace(persona.Nombre))
        {
            mensaje += "El nombre no puede estar vacio \n";
        }

        if (string.IsNullOrWhiteSpace(persona.Apellido))
        {
            mensaje += "El apellido no puede estar vacio \n";
        }

        if (string.IsNullOrWhiteSpace(persona.DNI))
        {
            mensaje += "El DNI no puede estar vacio \n";
        }

        if (string.IsNullOrWhiteSpace(persona.Email))
        {
            mensaje += "El email no puede estar vacio \n";
        }

        if (_repositorio.obtenerPorDNI(persona.DNI) != null)
        {
            mensaje += "El DNI ya existe \n";
        }

        if (_repositorio.obtenerPorEmail(persona.Email)!= null)
        {
            mensaje += "El email ya existe \n";
        }

        return mensaje == "";
    }
}