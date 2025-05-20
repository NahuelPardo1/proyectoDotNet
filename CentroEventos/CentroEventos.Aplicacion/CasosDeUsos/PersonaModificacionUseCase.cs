namespace CentroEventos.Aplicacion;
public class PersonaModificacionUseCase
{
    private readonly IRepositorioPersona _repositorioPersona;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public PersonaModificacionUseCase(IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
    {
        this._repositorioPersona = repositorioPersona;
        this._servicioAutorizacion = servicioAutorizacion;
    }
    public void Ejecutar(int IdPersonaAModificar, Persona personaModificada, int IdUsuario )
    {
        // 1. Verificar permiso
        if (!_servicioAutorizacion.PoseeElPermiso(IdUsuario, Permiso.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("El usuario no posee el permiso para relizar esta acción");
        }

        // 2. Verificar existencia de la persona
        Persona? persona = _repositorioPersona.ObtenerPorID(IdPersonaAModificar);
        if (persona == null)
        {
            throw new EntidadNotFoundException("La persona a modificar no existe");
        }

        // 3. Modificar 
        _repositorioPersona.Modificar(personaModificada,IdPersonaAModificar);
    }
}