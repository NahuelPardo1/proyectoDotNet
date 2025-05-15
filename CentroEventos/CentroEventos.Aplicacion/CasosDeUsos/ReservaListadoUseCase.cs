namespace CentroEventos.Aplicacion;
public class ReservaListadoUseCase
{
    private readonly IRepositorioReserva _repositorioReserva;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public ReservaListadoUseCase(IRepositorioReserva repositorioReserva, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioReserva = repositorioReserva;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public List<Reserva> Ejecutar(int idUsuario)
    {
        // 1. Verificar permiso
        if (! _servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaListado))
        {
            throw new FalloAutorizacionException("El responsable no posee el permiso para realizar esta accion");
        }
        // 2. Listar reservas
        return _repositorioReserva.Listar();
    }