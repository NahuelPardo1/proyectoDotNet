using System;
using System.Threading;

namespace CentroEventos.Aplicacion;

public class EventoDeportivoAltaUseCase { 
    private readonly IRepositorioPersona _repositorioPersona;
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;
    private readonly IServicioAutorizacion _servicioAutorizacion;



    public EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioPersona repositorioPersona,IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
        _repositorioPersona = repositorioPersona;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public void Ejecutar(EventoDeportivo eDeportivo)
    {
        DateTime fechaActual = DateTime.Now;
        if(eDeportivo.FechaHoraInicio < fechaActual)
        {
            throw new ValidacionException("La fecha de inicio no puede ser menor a la fecha actual");
        }
        if (_servicioAutorizacion.PoseeElServicio(eDeportivo.ResponsbleID,Permiso.EventoAlta ) == false)
        {
            throw new FalloAutorizacionException("El responsable no posee el permiso para realizar esta accion");
        }
        
        ValidadorEventoPersona validador = new ValidadorEventoPersona(_repositorioPersona);
        if(validador.Validar(eDeportivo, out string msgError))
        {
            _repositorioEventoDeportivo.Agregar(eDeportivo);
        }
        else
        {
            throw new ValidacionException(msgError);
        }

    }
}