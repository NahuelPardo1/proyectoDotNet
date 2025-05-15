namespace CentroEventos.Aplicacion;
public class PersonaListadoUseCase
{
    private readonly IRepositorioPersona _repositorioPersona;
    private readonly IServicioAutorizacion _servicioAutorizacion
    public PersonaListadoUseCase(IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioPersona = repositorioPersona;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public List<Persona> Ejecutar(int idUsuario)
    {
        // 1. Verificar permiso
        if (_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioListado))
        {
            throw new FalloAutorizacionException("El usuario no posee el permiso para relizar esta acción");
        }
        // 2. Listar personas
        return _repositorioPersona.Listar();
    }
}