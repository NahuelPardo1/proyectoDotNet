namespace CentroEventos.Aplicacion;
public class PersonaModificacionUseCase
{
    private readonly IRepositorioPersona repositorioPersona;
    private readonly IServicioAutorizacion servicioAutorizacion
    public PersonaModificacionUseCase(IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
    {
        this.repositorioPersona = repositorioPersona;
        this.servicioAutorizacion = servicioAutorizacion;
    }
    public void Ejecutar(Persona persona)
    {
        if(servicioAutorizacion.PoseeElPermiso(persona.Id, Permiso.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("El usuario no posee el permiso para relizar esta acción");
        }

        ValidadorPersona validador = new ValidadorPersona(repositorioPersona);
        if (!validador.Validador(persona, out string msj))
        {
            throw new ValidacionException(msj);
        }
        repositorioPersona.Modificar(persona)
    }
}