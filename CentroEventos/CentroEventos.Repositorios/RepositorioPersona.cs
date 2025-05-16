namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
using System.Collections.Generic;

public class RepositorioPersona : IRepositorioPersona {
    readonly string _nombreArchivo = "personas.txt";
    public void Agregar(Persona persona)
    {
        using var sw = new StreamWriter(_nombreArchivo, true);
        {
            sw.WriteLine(persona.Id);
            sw.WriteLine(persona.Nombre);
            sw.WriteLine(persona.DNI);
            sw.WriteLine(persona.Apellido);
            sw.WriteLine(persona.Email);
            sw.WriteLine(persona.Telefono);
        }
    }


    public void Modificar(Persona persona,int id) {
        
    }

}