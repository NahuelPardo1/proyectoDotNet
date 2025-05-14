namespace CentroEventos.Aplicacion;
public class PersonaAltaUseCase
    {
        private readonly IRepositorioPersona _repositorioPersona;
        private readonly IServicioAutorizacion _servicioAutorizacion;
        private readonly Permiso _permisoUsuarioAlta = Permiso.UsuarioAlta;
        public PersonaAltaUseCase(IRepositorioPersona repositorioPersona, IServicioAutorizacion, servicioAutorizacion)
        {
            _repositorioPersona = repositorioPersona;
            _servicioAutorizacion = servicioAutorizacion;
        }
        public void Ejecutar(Persona persona)
        {
            if (_servicioAutorizacion.PoseeElPermiso(persona.Id, _permisoUsuarioAlta))
            {
                ValidadorPersona validador = new ValidadorPersona(_repositorioPersona);
                if (!validador.Validador(persona, out string msj))
                {

                    throw new ValidacionException(msj);
                }
                _repositorioPersona.Agregar(persona);
            }else
            {
                throw new FalloAutorizacionException();
            }
        }
    }