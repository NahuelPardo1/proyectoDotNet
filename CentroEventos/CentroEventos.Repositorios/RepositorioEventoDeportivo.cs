namespace CentroEvento.Repositorio;
using CentroEventos.Aplicacion;
using System.IO;
public class RepositorioEventoDeportivo: IRepositorioEventoDeportivo
{
    private readonly string _ruta;
    private readonly string _rutaUltimoId;
    public RepositorioEventoDeportivo()
    {
        string dirCapeta = Path.Combine(Environment.CurrentDirectory, "DataBase");

        if (!Directory.Exists(dirCapeta))
        {
            Directory.CreateDirectory(dirCapeta);
        }
        _ruta = Path.Combine(dirCapeta, "EventosDeportivos.txt");
        _rutaUltimoId = Path.Combine(dirCapeta, "UltimoId.txt");
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
        sw.WriteLine(evento.ToString());
        sw.Close();
    }
    public List<EventoDeportivo> Listar()
    {
        List<EventoDeportivo> eventos = new List<EventoDeportivo>();
        StreamReader sr = new StreamReader(_ruta);
        string linea;
        while (!sr.EndOfStream)
        {
            linea = sr.ReadLine();
            string[] parte = linea.Split('|');
            EventoDeportivo evento = new EventoDeportivo();


        }
        return eventos;
    }
}