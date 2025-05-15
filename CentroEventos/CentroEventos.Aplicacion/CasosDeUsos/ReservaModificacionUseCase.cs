namespace CentroEventos.Aplicacion;
public class ReservaModificacionUseCase;
{
    private readonly IServicioAutorizacion _servicioAutorizacion;
    private readonly IRepositorioReserva _repositorioReserva;
    
    public ReservaModificacionUseCase(IRepositorioReserva repositorioReserva, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioReserva = repositorioReserva;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public void Ejecutar(int idReserva, Reserva reserva, int idUsuario)
    {
        // 1. Verificar permiso
        if (! _servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion))
        {
            throw new FalloAutorizacionException("El responsable no posee el permiso para realizar esta accion");
        }
        // 2. Verificar existencia de la reserva
        if (! _repositorioReserva.ObtenerPorID(idReserva))
        {
            throw new EntidadNotFoundException("La reserva no existe");
        }
        // 3. Verificar si la reserva modificada es valida
        ValidadorReserva validadorReserva = new ValidadorReserva(_repositorioReserva, out string msj);
        if (!validadorReserva.Validar(reserva, out msj))
        {
            throw new ValidacionException(msj);
        }
        // 4. Modificar reserva
        _repositorioReserva.Modificar(idReserva, reserva);
    }
}