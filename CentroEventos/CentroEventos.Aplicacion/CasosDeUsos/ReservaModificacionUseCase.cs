namespace CentroEventos.Aplicacion;
public class ReservaModificacionUseCase
{
    private readonly IServicioAutorizacion _servicioAutorizacion;
    private readonly IRepositorioReserva _repositorioReserva;
    private readonly IRepositorioPersona _repositorioPersona;
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;

    public ReservaModificacionUseCase(IRepositorioReserva repositorioReserva, IServicioAutorizacion servicioAutorizacion, IRepositorioPersona repositorioPersona, IRepositorioEventoDeportivo repositorioEventoDeportivo)
    {
        _repositorioReserva = repositorioReserva;
        _servicioAutorizacion = servicioAutorizacion;
        _repositorioPersona = repositorioPersona;
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
    }
    public void Ejecutar(int idReserva, Reserva reserva, int idUsuario)
    {
        // 1. Verificar permiso
        if (! _servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion))
        {
            throw new FalloAutorizacionException("El responsable no posee el permiso para realizar esta accion");
        }
        // 2. Verificar existencia de la reserva
        if (_repositorioReserva.ObtenerPorID(idReserva) == null)
            {
            throw new EntidadNotFoundException("La reserva no existe");
        }
        // 3. Verificar si la reserva modificada es valida
        ValidadorReserva validadorReserva = new ValidadorReserva(_repositorioPersona, _repositorioEventoDeportivo, _repositorioReserva);
        if (!validadorReserva.Validar(reserva, out string msj))
        {
            throw new ValidacionException(msj);
        }
        // 4. Modificar reserva
        _repositorioReserva.Modificar(reserva,idReserva);
    }
}