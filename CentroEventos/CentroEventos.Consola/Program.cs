using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;

//Creo los repositorios
IRepositorioReserva repositorioReserva = new RepositorioReserva();
IRepositorioEventoDeportivo repositorioEventoDeportivo = new RepositorioEventoDeportivo();
IRepositorioPersona repositorioPersona = new RepositorioPersona();

//Servicio de autorizacion provisional
IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();

//Creo los casos de uso y inyecto dependencias
PersonaAltaUseCase agregarPersona = new PersonaAltaUseCase(repositorioPersona, servicioAutorizacion);
PersonaBajaUseCase eliminarPersona = new PersonaBajaUseCase(repositorioPersona, servicioAutorizacion, repositorioEventoDeportivo, repositorioReserva);
PersonaModificacionUseCase editarPersona = new PersonaModificacionUseCase(repositorioPersona, servicioAutorizacion);
PersonaListadoUseCase listarPersonas = new PersonaListadoUseCase(repositorioPersona);
EventoDeportivoAltaUseCase agregarEvento = new EventoDeportivoAltaUseCase(repositorioEventoDeportivo,repositorioPersona, servicioAutorizacion);
EventoDeportivoBajaUseCase eliminarEvento = new EventoDeportivoBajaUseCase(repositorioEventoDeportivo,repositorioReserva,servicioAutorizacion);
EventoDeportivoModificacionUseCase editarEvento = new EventoDeportivoModificacionUseCase(repositorioEventoDeportivo,repositorioPersona, servicioAutorizacion);
EventoDeportivoListadoUseCase listarEventos = new EventoDeportivoListadoUseCase(repositorioEventoDeportivo);
ReservaAltaUseCase agregarReserva = new ReservaAltaUseCase(repositorioReserva, servicioAutorizacion, repositorioPersona,repositorioEventoDeportivo);
ReservaBajaUseCase eliminarReserva = new ReservaBajaUseCase(repositorioReserva, servicioAutorizacion);
ReservaModificacionUseCase editarReserva = new ReservaModificacionUseCase(repositorioReserva,servicioAutorizacion,repositorioPersona,repositorioEventoDeportivo);
ReservaListadoUseCase listarReservas = new ReservaListadoUseCase(repositorioReserva);
ListarAsistenciaAEventoUseCase listarAsistenciaAEvento = new ListarAsistenciaAEventoUseCase(repositorioEventoDeportivo,repositorioPersona, repositorioReserva);
ListarEventosConCupoDisponibleUseCase listarEventosConCupoDisponible = new ListarEventosConCupoDisponibleUseCase(repositorioEventoDeportivo,repositorioReserva);

int id = 0;
Persona? usuario;
bool sigue = true;
Console.WriteLine("BIENVENIDO AL SISTEMA DE GESTIÓN DEL CENTRO DEPORTIVO UNIVERSITARIO");
Console.WriteLine();
Console.WriteLine("Ingrese su DNI: ");

string? dni = Console.ReadLine();
if (!string.IsNullOrWhiteSpace(dni)) {
    usuario = repositorioPersona.obtenerPorDNI(dni);
    if (usuario == null)
    {
        usuario = new Persona();
        Console.WriteLine("El DNI ingresado no existe en el sistema, por favor registrese primero.\n");
        Console.WriteLine("Ingrese su nombre: ");
        usuario.Nombre = Console.ReadLine();
        Console.WriteLine("Ingrese su apellido: ");
        usuario.Apellido = Console.ReadLine();
        Console.WriteLine("Ingrese su DNI: ");
        usuario.DNI = Console.ReadLine();
        Console.WriteLine("Ingrese su email: ");
        usuario.Email = Console.ReadLine();
        Console.WriteLine("Ingrese su telefono: ");
        usuario.Telefono = Console.ReadLine();
        try {
            agregarPersona.Ejecutar(usuario, 1);
        }

        catch(Exception ex) {
            Console.WriteLine(ex);
        }
    }
    else {
        Console.WriteLine("Bienvenido " + usuario.Nombre + " " + usuario.Apellido);
    }
    id= usuario.Id;
}

do
{
    Console.WriteLine();
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Listar personas");
    Console.WriteLine("2. Agregar persona");
    Console.WriteLine("3. Modificar persona");
    Console.WriteLine("4. Eliminar persona");
    Console.WriteLine("5. Listar eventos deportivos");
    Console.WriteLine("6. Agregar evento deportivo");
    Console.WriteLine("7. Modificar evento deportivo");
    Console.WriteLine("8. Eliminar evento deportivo");
    Console.WriteLine("9. Listar reservas");
    Console.WriteLine("10. Agregar reserva");
    Console.WriteLine("11. Modificar reserva");
    Console.WriteLine("12. Eliminar reserva");
    Console.WriteLine("13. Listar asistencia a evento deportivo");
    Console.WriteLine("14. Listar eventos deportivos con cupo disponible");
    Console.WriteLine("15. Salir");
    string? opcion = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(opcion))
    {
        int num = int.Parse(opcion);
        switch (num)
        {
            case 0:
                {
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
                }
            case 1:
                {
                    List<Persona> personas = listarPersonas.Ejecutar();
                    if (personas.Count == 0)
                    {
                        Console.WriteLine("No hay personas registradas.");
                    }
                    else
                    {
                        Console.WriteLine("Personas registradas: ");
                        personas.ForEach(p => Console.WriteLine(p.ToString()));
                    }
                    break;
                }
            case 2:
                {
                    try
                    {
                        Persona p = new Persona();
                        Console.WriteLine("Ingrese el nombre de la persona a añadir: ");
                        p.Nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido de la persona a añadir: ");
                        p.Apellido = Console.ReadLine();
                        Console.WriteLine("Ingrese el DNI de la persona a añadir: ");
                        p.DNI = Console.ReadLine();
                        Console.WriteLine("Ingrese el email de la persona a añadir: ");
                        p.Email = Console.ReadLine();
                        Console.WriteLine("Ingrese el telefono de la persona a añadir: ");
                        p.Telefono = Console.ReadLine();
                        agregarPersona.Ejecutar(p, id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                }
            case 3:
                {
                    try
                    {
                        Persona p = new Persona();
                        Console.WriteLine("Ingrese el ID de la persona a modificar: ");
                        int idModificar = int.Parse(Console.ReadLine() ?? "0");
                        Console.WriteLine("Ingrese el nuevo nombre de la persona: ");
                        p.Nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el nuevo apellido de la persona: ");
                        p.Apellido = Console.ReadLine();
                        Console.WriteLine("Ingrese el nuevo DNI de la persona: ");
                        p.DNI = Console.ReadLine();
                        Console.WriteLine("Ingrese el nuevo email de la persona: ");
                        p.Email = Console.ReadLine();
                        Console.WriteLine("Ingrese el nuevo telefono de la persona: ");
                        p.Telefono = Console.ReadLine();
                        if(string.IsNullOrWhiteSpace(p.Nombre) || string.IsNullOrWhiteSpace(p.Apellido) || string.IsNullOrWhiteSpace(p.Email) || string.IsNullOrWhiteSpace(p.Telefono))
                        {
                            throw new ValidacionException("Los campos no pueden estar vacios");
                        }
                        editarPersona.Ejecutar(idModificar,p, id);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                }
            case 4:
                {
                    try
                    {
                        Console.WriteLine("Ingrese el ID de la persona a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine() ?? "0");
                        eliminarPersona.Ejecutar(idEliminar, id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                }
            case 5:
                {
                    List<EventoDeportivo> eventos = listarEventos.Ejecutar();
                    if (eventos.Count == 0)
                    {
                        Console.WriteLine("No hay eventos deportivos registrados.");
                    }
                    else
                    {
                        Console.WriteLine("Eventos deportivos:\n");
                        eventos.ForEach(e => Console.WriteLine(e.ToString()+"\n"));
                    }
                    break;
                }
            case 6:
                {
                    try
                    {
                        
                        EventoDeportivo evento = new EventoDeportivo();
                        Console.WriteLine("Ingrese el nombre del evento deportivo a añadir: ");
                        evento.Nombre = Console.ReadLine();
                        
                        Console.WriteLine("Ingrese la descripcion del evento deportivo a añadir: ");
                        evento.Descripcion = Console.ReadLine();
                        
                        Console.WriteLine("Ingrese la fecha y hora de inicio del evento deportivo a añadir (dd/MM/yyyy HH:mm): ");
                        evento.FechaHoraInicio = DateTime.ParseExact(Console.ReadLine() ?? "0", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                        Console.WriteLine("Ingrese la duracion del evento deportivo");
                        evento.DuracionHoras = double.Parse(Console.ReadLine() ?? "0");

                        Console.WriteLine("Ingrese la cantidad de personas que pueden asistir al evento deportivo a añadir: ");
                        evento.CupoMaximo = int.Parse(Console.ReadLine() ?? "0");
                        
                        Console.WriteLine("Ingrese el ID de la persona que organiza el evento deportivo a añadir: ");
                        evento.ResponsbleID = int.Parse(Console.ReadLine() ?? "0");
                        
                        agregarEvento.Ejecutar(evento, id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                }
            case 7:
                {
                    try
                    { 
                        Console.WriteLine("Ingrese el ID del evento deportivo a modificar: ");
                        int idModificar = int.Parse(Console.ReadLine() ?? "0");

                        Console.WriteLine("Ingrese el nuevo nombre del evento deportivo: ");
                        string? Nombre = Console.ReadLine();
                        
                        Console.WriteLine("Ingrese la nueva descripcion del evento deportivo: ");
                        string? Descripcion = Console.ReadLine();
                        
                        Console.WriteLine("Ingrese la nueva fecha y hora de inicio del evento deportivo (dd/MM/yyyy HH:mm): ");
                        DateTime FechaHoraInicio = DateTime.ParseExact(Console.ReadLine() ?? "0", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                        
                        Console.WriteLine("Ingrese la nueva duracion del evento deportivo: ");
                        double DuracionHoras = double.Parse(Console.ReadLine() ?? "0");
                        
                        Console.WriteLine("Ingrese la nueva cantidad de personas que pueden asistir al evento deportivo: ");
                        int CupoMaximo = int.Parse(Console.ReadLine() ?? "0");
                        
                        Console.WriteLine("Ingrese el nuevo ID de la persona que organiza el evento deportivo: ");
                        int ResponsbleID = int.Parse(Console.ReadLine() ?? "0");
                        EventoDeportivo eventoModificado = new EventoDeportivo(Nombre, Descripcion, FechaHoraInicio, DuracionHoras, CupoMaximo, ResponsbleID);

                        editarEvento.Ejecutar(idModificar,eventoModificado,id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                }
            case 8:
                {
                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                }
            case 9:
                {
                    List<Reserva> reservas = listarReservas.Ejecutar();
                    if(reservas.Count == 0)
                    {
                        Console.WriteLine("No hay reservas registradas.");
                    }
                    else
                    {
                        Console.WriteLine("Reservas: ");
                        reservas.ForEach(r => Console.WriteLine(reservas.ToString()));
                    }
                    break;
                }
            case 10:
                {
                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                }
            case 11:
                {
                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                }
            case 12:
                {
                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                }
            case 13:
                {
                    try
                    {
                        Console.WriteLine("Ingrese el ID del evento deportivo: ");
                        int idEvento = int.Parse(Console.ReadLine() ?? "0");
                        List<Persona> asistencia = listarAsistenciaAEvento.Ejecutar(idEvento);
                        if(asistencia.Count == 0)
                        {
                            Console.WriteLine("Nadie asistió a este evento");
                        }
                        else
                        {
                            Console.WriteLine("Personas que asistieron al evento ingresado: ");
                            asistencia.ForEach(a => Console.WriteLine(a.ToString()));
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                }
            case 14:
                {
                    List<EventoDeportivo> eventosConCupo = listarEventosConCupoDisponible.Ejecutar();
                    if (eventosConCupo.Count == 0)
                    {
                        Console.WriteLine("No hay eventos con cupo disponible");
                    }
                    else
                    { 
                        eventosConCupo.ForEach(e => Console.WriteLine(e.ToString()));
                    }
                        break;
                }
            case 15:
                {
                    sigue = false;
                    break;
                }
            default:
                {
                     Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
                }

        }
    }
}
while (sigue);
