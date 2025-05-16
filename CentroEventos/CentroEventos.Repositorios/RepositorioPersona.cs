namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
using System.IO;

public class RepositorioPersona: IRepositorioPersona 
{
    readonly string _nombreArchivo = "DataBase/Personas.txt";
    readonly string _ultimoId = "DataBase/PersonasUltimoId.txt"
    public void Agregar(Persona persona)
    {
        lastId = ObtenerUltimoID();

        using var sw = new StreamWriter(_nombreArchivo, true);
        sw.WriteLine(persona.Id);
        sw.WriteLine(persona.Nombre);
        sw.WriteLine(persona.DNI);
        sw.WriteLine(persona.Apellido);
        sw.WriteLine(persona.Email);
        sw.WriteLine(persona.Telefono);
        Persona persona = new Persona();
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


    public void Modificar(Persona persona,int id) {
        
    }
    

}