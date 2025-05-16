namespace CentroEventos.Aplicacion;
public class PersonaModificacionUseCase
{
    private readonly IRepositorioPersona repositorioPersona;
    private readonly IServicioAutorizacion servicioAutorizacion;
    public PersonaModificacionUseCase(IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
    {
        this.repositorioPersona = repositorioPersona;
        this.servicioAutorizacion = servicioAutorizacion;
    }
    public void Ejecutar(int IdPesonaAModificar, Persona personaModificada, int IdUsuario )
    {
        // 1. Verificar permiso
        if (servicioAutorizacion.PoseeElPermiso(IdUsuario, Permiso.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("El usuario no posee el permiso para relizar esta acción");
        }

        // 2. Verificar existencia de la persona
        Persona? persona = repositorioPersona.ObtenerPorID(IdPesonaAModificar);
        if (persona == null)
        {
            throw new EntidadNotFoundException("La persona a modificar no existe");
        }

        // 3. Validad datos
        ValidadorPersona validador = new ValidadorPersona(repositorioPersona);
        if (!validador.Validador(personaModificada, out string msj))
        {
            throw new ValidacionException(msj);
        }

        // 4. Actualizar ID para asegurar que se mantenga el orden
        personaModificada.Id = IdPesonaAModificar;

        // 5. Modificar 
        repositorioPersona.Modificar(personaModificada, IdPesonaAModificar);
    }
}