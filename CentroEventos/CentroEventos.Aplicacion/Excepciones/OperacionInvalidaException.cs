namespace CentroEventos.Aplicacion;

public class OperacionInvalidaException : Exception
{
    public OperacionInvalidaException(string mensaje) : base(mensaje) { }
    public OperacionInvalidaException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
}