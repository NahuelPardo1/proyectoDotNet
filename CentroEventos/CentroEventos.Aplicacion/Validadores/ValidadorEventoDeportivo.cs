namespace CentroEvento.Aplicacion.Validadores;

public class ValidadorEventoDeportivo
{
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
        IPersona p = obtenerID(eDeportivo.ResponsbleID);
        if (p==null)
        {
            msgError+= "Responsable del evento deportivo no existe.\n";
        }
        return msgError == "";
    }
}