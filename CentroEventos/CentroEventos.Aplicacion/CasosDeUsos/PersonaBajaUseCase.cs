namespace CentroEventos.Aplicacion;
public class PersonaBajaUseCase
{
    private readonly IRepositorioPersona _repositorioPersona
    private readonly IServicioAutorizacion _servicioAutorizacion;
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;
    private readonly IRepositorioReserva _repositorioReserva;
    
    public PersonaBajaUseCase(IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion, IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioReserva repositorioReserva)
    {
        _repositorioPersona = repositorioPersona;
        _servicioAutorizacion = servicioAutorizacion;
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
        _repositorioReserva = repositorioReserva;
    }
    public void Ejecutar (int IDBaja, int IdUsuario)
    {
        // 1. Verificar permiso
        if (_servicioAutorizacion.PoseeElPermiso(IdUsuario, Permiso.UsuarioBaja))
        {
            throw new FalloAutorizacionException("El usuario no posee el permiso para relizar esta acción");
        }
        // 2. Verificar existencia de la persona
        Persona persona = _repositorioPersona.ObtenerPorId(IDBaja); 
        if (persona == null)
        {
            throw new EntidadNotFoundException("La persona a eliminar no existe"); 
        }
        // 3. Verificar reservas asociadas
        List<Reserva> reservas = _repositorioReserva.ObtenerPorPersona(IDBaja); 
        if (reservas != null && reservas.Count >0)
        {
            throw new OperacionInvalidaException("El persona a eliminar tiene reservas");
        }
        // 4. Verificar si es responsable de algún evento deportivo
        List<EventoDeportivo> eventos = _repositorioEventoDeportivo.ObtenerPorPersona(IDBaja);
        if (eventos != null && eventos.Count> 0)
        {
            throw new OperacionInvalidaException("El persona a eliminar tiene eventos deportivos");
        }
        // 5. Eliminar persona
        _repositorioPersona.Eliminar(IDBaja);
    }
}