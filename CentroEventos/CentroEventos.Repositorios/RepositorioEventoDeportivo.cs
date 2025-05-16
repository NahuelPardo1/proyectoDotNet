namespace CentroEvento.Repositorio;
using CentroEventos.Aplicacion;
public class RepositorioEventoDeportivo: IRepositorioEventoDeportivo
{
    readonly string _ruta = "DataBase/EventoDeportivo.txt";
    readonly string _rutaUltimoId = "DataBase/EventoDeportivoUtlimoId.txt";
}