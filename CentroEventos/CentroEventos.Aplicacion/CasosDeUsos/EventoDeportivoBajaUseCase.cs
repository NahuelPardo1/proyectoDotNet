using System.Collections.Generic;

namespace CentroEventos.Aplicacion;

public class EventoDeportivoBajaUseCase
{
    private readonly IRepositorioEventoDeportivo _repositorioED;
    private readonly IRepositorioReserva _repositorioR;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public EventoDeportivoBajaUseCase(IRepositorioEventoDeportivo repositorioED, IRepositorioReserva repositorioR, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioED = repositorioED;
        _repositorioR = repositorioR;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(int idEvento, int idUsuario)
    {
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
        {
            throw new FalloAutorizacionException("El responsable no posee el permiso para realizar esta accion");
        }
        if (_repositorioED.ObtenerPorID(idEvento) == null)
        {
            throw new EntidadNotFoundException("El evento deportivo no existe");
        }
        List<Reserva> reservas = _repositorioR.ObtenerPorEvento(idEvento);
        if (reservas.Count > 0)
        {
            throw new OperacionInvalidaException("No se puede eliminar el evento deportivo porque tiene reservas asociadas");
        }
        else
        {
            _repositorioED.Eliminar(idEvento);
        }
    }

}