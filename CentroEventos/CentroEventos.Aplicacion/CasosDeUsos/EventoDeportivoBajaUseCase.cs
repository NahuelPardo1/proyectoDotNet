using System.Collections.Generic;

namespace CentroEventos.Aplicacion;

public class EventoDeportivoBajaUseCase
{
    private readonly IRepositorioEventoDeportivo _repositorioED;
    private readonly IRepositorioReserva _repositorioR;
    public EventoDeportivoBajaUseCase(IRepositorioEventoDeportivo repositorioED, IRepositorioReserva repositorioR)
    {
        _repositorioED = repositorioED;
        _repositorioR = repositorioR;
    }

    public void Ejecutar(int idEvento)
    {
        List<Reserva> reservas = _repositorioR.ObtenerPorEvento(idEvento);
        if (reservas == null)
        {
            
        }
        
    }

}