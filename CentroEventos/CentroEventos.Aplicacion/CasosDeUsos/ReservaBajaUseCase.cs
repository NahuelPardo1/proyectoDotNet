namespace CentroEvento.Aplicacion;
public class ReservaBajaUseCase
{
    private readonly IRespositorioReserva _repositorioReserva;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    
    public ReservaBajaUseCase(IRespositorioReserva repositorioReserva, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioReserva = repositorioReserva;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public void Ejecutar(Reserva reservaBaja, int IdUsuario)
    {
        // 1. Verificar permiso 
        if (! _servicioAutorizacion.PoseeElPermiso(IdUsuario, Permiso.ReservaBaja))
        {
            throw new FalloAutorizacionException("El usuario no posee el permiso para realizar esta acción");
        }
        // 2. Verificar existencia de la reserva
        Reserva reserva = _repositorioReserva.ObtenerPorID(reservaBaja.IdReserva);
        if (reserva == null)
        {
            throw new EntidadNotFoundException("La reserva no existe");
        }
        // . Dar de baja a la reserva
        _repositorioReserva.Baja(reservaBaja);
    }

}