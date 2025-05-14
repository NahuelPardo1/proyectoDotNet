namespace CentroEventos.Aplicacion;
public class PersonaBajaUseCase
{
    private readonly IRepositorioPersona _repositorioPersona;
    public PersonaBajaUseCase(IRepositorioPersona repositorioPersona)
    {
        _repositorioPersona = repositorioPersona;
    }
    public void Ejecutar (Persona persona)
    {
        ValidadorPersona validadorPersona = new ValidadorPersona(_repositorioPersona);
        if (!validadorPersona.Validador(persona, out string msj))
        {
            throw new ValidacionException(msj);
        }
        _repositorioPersona.Eliminar(persona);
    }
}