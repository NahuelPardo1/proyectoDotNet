namespace CentroEventos.Aplicacion;
    public class PersonaAltaUseCase
    {
        private readonly IRepositorioPersona _repositorioPersona;
        public PersonaAltaUseCase(IRepositorioPersona repositorioPersona)
        {
            _repositorioPersona = repositorioPersona;
        }
        public void Ejecutar(Persona persona)
        {
            ValidadorPersona validador = new ValidadorPersona(_repositorioPersona);
            if (!validador.Validador(persona,out string msj))
            {

                throw new ValidacionException(msj);
            }
             _repositorioPersona.Agregar(persona);
         }
    }