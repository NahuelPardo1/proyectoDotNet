namespace CentroEventos.Aplicacion;
public class PersonaListadoUseCase
{
    private readonly IRepositorioPersona _repositorioPersona;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public PersonaListadoUseCase(IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioPersona = repositorioPersona;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public List<Persona> Ejecutar()
    {
        return _repositorioPersona.Listar();
    }
}