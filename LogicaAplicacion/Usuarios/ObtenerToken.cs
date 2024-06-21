using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.CasoUso.Usuarios
{
    public class ObtenerToken : ILogin
    {
        private IRepositorioUsuario _repositorioUsuario;


        public ObtenerToken(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }


        public string Ejecutar(Usuario obj)
        {
            return _repositorioUsuario.obtenerToken(obj);
        }
    }
}
