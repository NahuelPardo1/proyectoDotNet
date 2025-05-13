namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva : IRepositorioBase<Reserva>
{
    private readonly IRepositorioPersona _repositorioP;

}