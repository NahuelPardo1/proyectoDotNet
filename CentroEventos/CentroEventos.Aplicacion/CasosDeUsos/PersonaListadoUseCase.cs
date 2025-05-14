namespace CentroEventos.Aplicacion;
public class PersonaListadoUseCase
{
    private readonly IRepositorioPersona _repositorioPersona;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    private readonly Permiso _permisoUsuarioListado = Permiso.UsuarioListado;
    public PersonaListadoUseCase(IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioPersona = repositorioPersona;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public List<Persona> Ejecutar(int idUsuario)
    {
        if (_servicioAutorizacion.PoseeElPermiso(idUsuario, _permisoUsuarioListado))
        {
            return _repositorioPersona.Listar();
        }
        else
        {
            throw new FalloAutorizacionException();
        }
    }
}