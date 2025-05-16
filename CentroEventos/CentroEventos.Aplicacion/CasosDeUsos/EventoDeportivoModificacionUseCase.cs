using CentroEvento.Aplicacion;
using System;

namespace CentroEventos.Aplicacion;

public class EventoDeportivoModificacionUseCase
{
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;
    private readonly IRepositorioPersona _repositorioPersona;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
        _servicioAutorizacion = servicioAutorizacion;
        _repositorioPersona = repositorioPersona;
    }

    public void Ejecutar(int idEvento, EventoDeportivo e, int idUsuario)
    {
        if (_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoModificacion) == false)
        {
            throw new FalloAutorizacionException("El responsable no posee el permiso para realizar esta accion");
        }
        if (_repositorioEventoDeportivo.ObtenerPorID(idEvento) == null)
        {
            throw new EntidadNotFoundException("El evento deportivo no existe");
        }

        if (e.FechaHoraInicio < DateTime.Now)
        {
            throw new OperacionInvalidaException("La fecha de inicio no puede ser menor a la fecha actual");
        }
        ValidadorEventoDeportivo validador = new ValidadorEventoDeportivo(_repositorioPersona);
        if (validador.Validar(e, out string msgError))
        {
            _repositorioEventoDeportivo.Modificar(e,idEvento);
        }
        else
        {
            throw new ValidacionException(msgError);
        }
    }