namespace CentroEventos.Aplicacion;
public class PersonaAltaUseCase
{
    private readonly IRepositorioPersona _repositorioPersona;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public PersonaAltaUseCase(IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioPersona = repositorioPersona;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public void Ejecutar(int IdAlta, int IdUsuario)
    {
        // 1. Verificar permiso
        if (! _servicioAutorizacion.PoseeElPermiso(IdUsuario, Permiso.UsuarioAlta))
        { 
            throw new FalloAutorizacionException("El usuario no posee el permiso para relizar esta acción"); 
        }
        // 2. Verificar existencia de la persona
        ValidadorPersona validador = new ValidadorPersona(_repositorioPersona);
        if (!validador.Validador(persona, out string msj))
        {

            throw new ValidacionException(msj);
        }
        // 3. Agregar persona
        _repositorioPersona.Agregar(persona);
    }
}