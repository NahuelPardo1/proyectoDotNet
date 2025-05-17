namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
using System.IO;

public class RepositorioPersona: IRepositorioPersona 
{
    readonly string _nombreArchivo = "DataBase/Personas.txt";
    readonly string _ultimoId = "DataBase/PersonasUltimoId.txt";
    public void Agregar(Persona persona)
    {
        int lastId = ObtenerUltimoID();
        persona.Id = lastId + 1;
        GuardarUltimoID(persona.Id);
        using var sw = new StreamWriter(_nombreArchivo, true);
        sw.WriteLine(persona.Id);
        sw.WriteLine(persona.Nombre);
        sw.WriteLine(persona.DNI);
        sw.WriteLine(persona.Apellido);
        sw.WriteLine(persona.Email);
        sw.WriteLine(persona.Telefono);
        Console.WriteLine("Se agrego a la persona correctamente");
    }
    private int ObtenerUltimoID()
    {
        if (!File.Exists(_ultimoId))
        {
            File.Create(_ultimoId).Close();
            return 0;
        }
        string ultimoId = File.ReadAllText(_ultimoId);
        return int.Parse(ultimoId);
    }
    private void GuardarUltimoID(int id)
    {
        StreamWriter sw = new StreamWriter(_ultimoId,false);
        sw.WriteLine(id);
        sw.Close();
    }

    public List<Persona> Listar() { 
        Persona persona = new Persona();
        List<Persona> personas = new List<Persona>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {
            persona.Id = int.Parse(sr.ReadLine());
            persona.Nombre = sr.ReadLine();
            persona.DNI = sr.ReadLine();
            persona.Apellido = sr.ReadLine();
            persona.Email = sr.ReadLine();
            persona.Telefono = sr.ReadLine();
            personas.Add(persona);
        }
        return personas;
    }


    public void Modificar(Persona persona,int id) {
        List<Persona> personas = Listar();
        for (int i = 0; i < personas.Count; i++)
        {
            if (personas[i].Id == id)
            {
                personas[i].Id = persona.Id;
                personas[i] = persona;
                break;
            }
        }
        using var sw = new StreamWriter(_nombreArchivo, false);
        foreach (var p in personas)
        {
            sw.WriteLine(p.Id);
            sw.WriteLine(p.Nombre);
            sw.WriteLine(p.DNI);
            sw.WriteLine(p.Apellido);
            sw.WriteLine(p.Email);
            sw.WriteLine(p.Telefono);
        }

    }

    public void Eliminar(int id) { 
        List<Persona> personas = Listar();
        for (int i = 0; i < personas.Count; i++)
        {
            if (personas[i].Id == id)
            {
                personas.RemoveAt(i);
                Console.WriteLine("Persona Eliminada");
                break;
            }
        }
        using var sw = new StreamWriter(_nombreArchivo, false);
        foreach (var p in personas)
        {
            sw.WriteLine(p.Id);
            sw.WriteLine(p.Nombre);
            sw.WriteLine(p.Apellido);
            sw.WriteLine(p.DNI);
            sw.WriteLine(p.Email);
            sw.WriteLine(p.Telefono);
        }
    }

    public Persona? obtenerPorDNI(string dni)
    {
        List<Persona> personas = Listar();
        foreach (var p in personas)
        {
            if (p.DNI == dni)
            {
                return p;
            }
        }
        return null;
    }

    public Persona? obtenerPorEmail(string email)
    {
        List<Persona> personas = Listar();
        foreach (var p in personas)
        {
            if (p.Email == email)
            {
                return p;
            }
        }
        return null;
    }

    public Persona? ObtenerPorID(int id)
    {
        List<Persona> personas = Listar();
        foreach (var p in personas)
        {
            if (p.Id == id)
            {
                return p;
            }
        }
        return null;
    }
    


}