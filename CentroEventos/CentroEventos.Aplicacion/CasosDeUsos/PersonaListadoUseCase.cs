namespace CentroEventos.Aplicacion;
public class PersonaListadoUseCase
{
    private readonly IRepositorioPersona _repositorioPersona;
    public PersonaListadoUseCase(IRepositorioPersona repositorioPersona)
    {
        _repositorioPersona = repositorioPersona;
    }
    public List<Persona> Ejecutar()
    {
        return _repositorioPersona.Listar();
    }
}