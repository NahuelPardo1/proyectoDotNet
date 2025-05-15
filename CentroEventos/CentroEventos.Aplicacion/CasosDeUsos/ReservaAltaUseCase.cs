namespace CentroEventos.Aplicacion;
public class ReservaAltaUseCase
{
    private readonly IRepositorioReserva _repositorioReserva;
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public ReservaAltaUseCase(IRepositorioReserva repositorioReserva,IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioReserva = repositorioReserva;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public void Ejecutar(Reserva datos, int IdUsuario)
    {
        // 1. Verificar permiso
        if (! _servicioAutorizacion.PoseeElPermiso(IdUsuario,Persmiso.ReservaAlta))
        { 
            throw new FalloAutorizacionException("El usuario no posee el permiso para relizar esta acción");
        }
        // 2. Validar Reserva 
        // 2.1 Verificar existencia de la persona
        // 2.2 Verificar existencia del evento deportivo
        // 2.3 Verificar que no exista una reserva para la misma persona y evento deportivo
        // 2.4 Verificar que haya cupo disponible para el evento deportivo
        ValidadorReserva validarReserva = new ValidadorReserva(_repositorioReserva,out string msj);
        if (!validarReserva.Validar(datos, out msj))
        {
            throw new ValidacionException(msj);
        }
        // 3. Agregar reserva
        _repositorioReserva.Agregar(datos);

        // preguntar al profe si es correcto 
    }
}