namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
using System.IO;
public class RepositorioEventoDeportivo: IRepositorioEventoDeportivo
{
    private readonly string _ruta;
    private readonly string _rutaUltimoId;
    public RepositorioEventoDeportivo()
    {
        string dirProyecto = AppDomain.CurrentDomain.BaseDirectory;
        string dirRepositorio = Path.Combine(dirProyecto, @"..\..\..\..\CentroEventos.Repositorios\DataBase");

        if (!Directory.Exists(dirRepositorio))
        {
            Directory.CreateDirectory(dirRepositorio);
        }
        _ruta = Path.Combine(dirRepositorio, "EventosDeportivos.txt");
        _rutaUltimoId = Path.Combine(dirRepositorio, "EventoUltimoId.txt");

        // Verificar si el archivo EventosDeportivos.txt existe, si no, crearlo vacío
        if (!File.Exists(_ruta))
        {
            File.Create(_ruta).Close();
        }
    }

    private int ObtenerUltimoID()
    {
        if (!File.Exists(_rutaUltimoId))
        {
            File.Create(_rutaUltimoId).Close();
            return 0;
        }
        string ultimoId = File.ReadAllText(_rutaUltimoId);
        return int.Parse(ultimoId);
    }
    private void GuardarUltimoID(int id)
    {
        StreamWriter sw = new StreamWriter(_rutaUltimoId);
        sw.WriteLine(id);
        sw.Close();
    }

    public void Agregar(EventoDeportivo evento)
    {
        int UtlimoId = ObtenerUltimoID() + 1;
        evento.Id = UtlimoId;
        GuardarUltimoID(UtlimoId);
        StreamWriter sw = new StreamWriter(_ruta, append: true);
        sw.WriteLine(evento.Id);
        sw.WriteLine(evento.Nombre); 
        sw.WriteLine(evento.Descripcion);
        sw.WriteLine(evento.FechaHoraInicio.ToString("yyyy-MM-dd HH:mm:ss"));
        sw.WriteLine(evento.DuracionHoras);
        sw.WriteLine(evento.CupoMaximo);
        sw.WriteLine(evento.ResponsbleID);
        sw.Close();
        Console.WriteLine($"Evento Deportivo {evento.Nombre} agregado con ID {evento.Id}.");
    }
    public List<EventoDeportivo> Listar()
    {
        List<EventoDeportivo> eventos = new List<EventoDeportivo>();
        EventoDeportivo evento = new EventoDeportivo();
        using StreamReader sr = new StreamReader(_ruta);
        while (!sr.EndOfStream)
        {
            evento.Id = int.Parse(sr.ReadLine());
            evento.Nombre = sr.ReadLine();
            evento.Descripcion = sr.ReadLine();                                               // para mantener el formato fijo y no depender de la hora del pais
            evento.FechaHoraInicio = DateTime.ParseExact(sr.ReadLine(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            evento.DuracionHoras = double.Parse(sr.ReadLine());
            evento.CupoMaximo = int.Parse(sr.ReadLine());
            evento.ResponsbleID = int.Parse(sr.ReadLine());
            eventos.Add(evento);
        }
        return eventos;
    }
    public void Modificar(EventoDeportivo evento, int id)
    {
        List<EventoDeportivo> eventos = Listar();
        for (int i = 0; i < eventos.Count; i++)
        {
            if (eventos[i].Id == id)
            {
                evento.Id = id; // mantener el ID original
                eventos[i] = evento;
                break;
            }
        }
        // rescribir el archivo completo 
        using StreamWriter sw = new StreamWriter(_ruta);
        foreach(EventoDeportivo e in eventos)
        {
            sw.WriteLine(e.ToString());
        }
        sw.Close();
        Console.WriteLine($"Evento Deportivo {evento.Nombre} modificado con ID {evento.Id}.");
    }
    public void Eliminar(int id)
    {
        List<EventoDeportivo> eventos = Listar();
        for (int i = 0; i < eventos.Count; i++)
        {
            if (eventos[i].Id == id)
            {
                eventos.RemoveAt(i);
                break;
            }
        }
        // rescribir el archivo completo 
        using StreamWriter sw = new StreamWriter(_ruta);
        foreach(EventoDeportivo e in eventos)
        {
            sw.WriteLine(e.ToString());
        }
        Console.WriteLine($"Evento Deportivo con ID {id} eliminado.");
    }

    public EventoDeportivo? ObtenerPorID(int id)
    {
        List<EventoDeportivo> eventos = Listar();
        foreach (EventoDeportivo evento in eventos)
        {
            if (evento.Id == id)
            {
                return evento;
            }
        }
        return null;
    }
    public List<EventoDeportivo> ObtenerPorPersona(int personaId)
    {
        List<EventoDeportivo> eventos = Listar();
        List<EventoDeportivo> eventosPorPersona = new List<EventoDeportivo>();
        foreach (EventoDeportivo evento in eventos)
        {
            if (evento.ResponsbleID == personaId)
            {
                eventosPorPersona.Add(evento);
            }
        }
        return eventosPorPersona;
    }
}