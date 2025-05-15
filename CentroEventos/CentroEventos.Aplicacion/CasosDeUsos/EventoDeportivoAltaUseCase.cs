

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
    public void Ejecutar(EventoDeportivo eDeportivo,int idUsuario)
    {
        if (_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoAlta) == false)
        {
            throw new FalloAutorizacionException("El responsable no posee el permiso para realizar esta accion");
        }
        if(_repositorioPersona.ObtenerPorID(eDeportivo.ResponsableID) == null)
        {
            throw new EntidadNotFoundException("El responsable no existe");
        }
        DateTime fechaActual = DateTime.Now;
        if(eDeportivo.FechaHoraInicio < fechaActual)
        {
            throw new OperacionInvalidaException("La fecha de inicio no puede ser menor a la fecha actual");
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