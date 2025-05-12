namespace CentroEvento.Aplicacion.Validadores;

public class ValidadorEventoDeportivo
{
	private readonly IRepositorioPersona _Rpersona;

    public ValidadorEventoDeportivo(IRepositorioEventoDeportivo e)
	{
		this._Rpersona = p;
	}

	public bool Validar(EventoDeportivo eDeportivo,out string msgError)
    {
        msgError = "";
        if (eDeportivo.Nombre.lenght < 0)
        {
            msgError += "Nombre del evento deportivo no puede ser vacio.\n";
        }

        if (eDeportivo.Descripcion.lenght < 0)
        {
            msgError += "Descripcion del evento deportivo no puede ser vacio.\n";
        }

        if (eDeportivo.CupoMaximo<0)
        {
            msgError += "Cupo maximo del evento deportivo no puede ser menor a 0.\n";
        }
        
        if (_Rpersona.ObtenerPorID(eDeportivo.ResponsbleID)==null)
        {
            msgError+= "Responsable del evento deportivo no existe.\n";
        }
        return msgError == "";
    }
}