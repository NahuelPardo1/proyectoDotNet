namespace CentroEventos.Aplicacion;
public class ReservaListadoUseCase
{
    private readonly IRepositorioReserva _repositorioReserva;
    public ReservaListadoUseCase(IRepositorioReserva repositorioReserva)
    {
        _repositorioReserva = repositorioReserva;
    }
    public List<Reserva> Ejecutar()
    {
        return _repositorioReserva.Listar();
    }
}