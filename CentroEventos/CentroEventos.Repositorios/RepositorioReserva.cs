namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion;

public class RepositorioReserva : IRepositorioReserva
{
    private readonly string _ruta;
    private readonly string _rutaUltimoId;
    public RepositorioReserva()
    {
        string dirProyecto = AppDomain.CurrentDomain.BaseDirectory;
        string dirRepositorio = Path.Combine(dirProyecto, @"..\..\..\..\CentroEventos.Repositorios\DataBase");

        if (!Directory.Exists(dirRepositorio))
        {
            Directory.CreateDirectory(dirRepositorio);
        }
        _ruta = Path.Combine(dirRepositorio, "Reservas.txt");
        _rutaUltimoId = Path.Combine(dirRepositorio, "ReservaUltimoId.txt");

        // Verificar si el archivo Reservas.txt existe, si no, crearlo vacío
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
    public void Agregar(Reserva reserva)
    {
        int UtlimoId = ObtenerUltimoID() + 1;
        reserva.Id = UtlimoId;
        GuardarUltimoID(UtlimoId);
        StreamWriter sw = new StreamWriter(_ruta, true);
        sw.WriteLine(reserva.Id);
        sw.WriteLine(reserva.EstadoReserva);
        sw.WriteLine(reserva.PersonaId);
        sw.WriteLine(reserva.EventoDeportivoId);
        sw.WriteLine(reserva.FechaAltaReserva);
        sw.Close();
        Console.WriteLine($"Reserva agregada con ID {reserva.Id}.");
    }
    public List<Reserva> Listar()
    {
        List<Reserva> reservas = new List<Reserva>();
        using StreamReader sr = new StreamReader(_ruta);
        while (!sr.EndOfStream)
        {
            Reserva reserva = new Reserva();
            reserva.Id = int.Parse(sr.ReadLine());
            reserva.EstadoReserva = Enum.Parse<Estado>(sr.ReadLine());
            reserva.PersonaId = int.Parse(sr.ReadLine());
            reserva.EventoDeportivoId = int.Parse(sr.ReadLine());
            reserva.FechaAltaReserva = DateTime.Parse(sr.ReadLine());
            reservas.Add(reserva);
        }
        return reservas;
    }
    public void Modificar(Reserva reserva, int id)
    {
        List<Reserva> reservas = Listar();
        for (int i = 0; i < reservas.Count; i++)
        {
            if (reservas[i].Id == id)
            {
                reserva.Id = id;
                reservas[i] = reserva;
                break;
            }
        }
        StreamWriter sw = new StreamWriter(_ruta);
        foreach(Reserva r in reservas)
        {
            sw.WriteLine(r.Id);
            sw.WriteLine(r.EstadoReserva);
            sw.WriteLine(r.PersonaId);
            sw.WriteLine(r.EventoDeportivoId);
            sw.WriteLine(r.FechaAltaReserva);
        }
        sw.Close();
        Console.WriteLine($"Reserva modificada con ID {reserva.Id}.");
    }
    public void Eliminar(int id)
    {
        List<Reserva> reservas = Listar();
        for (int i = 0; i < reservas.Count; i++)
        {
            if (reservas[i].Id == id)
            {
                reservas.RemoveAt(i);
                break;
            }
        }
        StreamWriter sw = new StreamWriter(_ruta);
        foreach (Reserva r in reservas)
        {
            sw.WriteLine(r.Id);
            sw.WriteLine(r.EstadoReserva);
            sw.WriteLine(r.PersonaId);
            sw.WriteLine(r.EventoDeportivoId);
            sw.WriteLine(r.FechaAltaReserva);
        }
        sw.Close();
        Console.WriteLine($"Reserva eliminada con ID {id}.");
    }
    public Reserva? ObtenerPorID(int id)
    {
        List<Reserva> reservas = Listar();
        foreach (Reserva r in reservas)
        {
            if (r.Id == id)
            {
                return r;
            }
        }
        return null;
    }
    public Reserva? ObtenerPorPersonaYEvento(int personaId, int eventoId)
    {
        List<Reserva> reservas = Listar();
        foreach (Reserva r in reservas)
        {
            if (r.PersonaId == personaId && r.EventoDeportivoId == eventoId)
            {
                return r;
            }
        }
        return null;
    }
    public List<Reserva> ObtenerPorEvento(int eventoId)
    {
        List<Reserva> reservas = Listar();
        List<Reserva> reservasPorEvento = new List<Reserva>();
        foreach (Reserva r in reservas)
        {
            if (r.EventoDeportivoId == eventoId)
            {
                reservasPorEvento.Add(r);
            }
        }
        return reservasPorEvento;
    }
    public List<Reserva> ObtenerPorPersona(int personaId)
    {
        List<Reserva> reservas = Listar();
        List<Reserva> reservasPorPersona = new List<Reserva>();
        foreach (Reserva r in reservas)
        {
            if (r.PersonaId == personaId)
            {
                reservasPorPersona.Add(r);
            }
        }
        return reservasPorPersona;
    }
}