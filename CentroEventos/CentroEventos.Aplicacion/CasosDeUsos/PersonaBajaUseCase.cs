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
        if (_servicioAutorizacion.PoseeElPermiso(IdUsuario, Permiso.UsuarioBaja))
        {
            throw new FalloAutorizacionException("El usuario no posee el permiso para relizar esta acción");
        }
        
        Persona persona = _repositorioPersona.ObtenerPorId(IDBaja); // si la persona a eliminar no existe 
        if (persona == null)
        {
            throw new EntidadNotFoundException("La persona a eliminar no existe"); 
        }
        List<Reserva> reservas = _repositorioReserva.ObtenerPorPersona(IDBaja); // si la persona tiene reservas 
        if (reservas != null)
        {
            throw new OperacionInvalidaException("El persona a eliminar tiene reservas");
        }
        List<EventoDeportivo> eventos = _repositorioEventoDeportivo.ObtenerPorPersona(IDBaja); // si la persona tiene eventos deportivos
        if (eventos != null)
        {
            throw new OperacionInvalidaException("El persona a eliminar tiene eventos deportivos");
        }
        _repositorioPersona.Eliminar(IDBaja);
    }
}