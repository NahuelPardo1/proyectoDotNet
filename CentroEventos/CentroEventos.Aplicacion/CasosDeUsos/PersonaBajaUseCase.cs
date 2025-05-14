namespace CentroEventos.Aplicacion;
public class PersonaBajaUseCase
{
    private readonly IRepositorioPersona _repositorioPersona;
    private readonly Permiso _permisoUsuarioBaja = Permiso.UsuarioBaja;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public PersonaBajaUseCase(IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioPersona = repositorioPersona;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public void Ejecutar (Persona persona)
    {
        if (_servicioAutorizacion.PoseeElPermiso(persona.Id, _permisoUsuarioBaja))
        {
            ValidadorPersona validadorPersona = new ValidadorPersona(_repositorioPersona);
            if (!validadorPersona.Validador(persona, out string msj))
            {
                throw new ValidacionException(msj);
            }
            _repositorioPersona.Eliminar(persona);
        }
        else
        {
            throw new FalloAutorizacionException();
        }
    }
}