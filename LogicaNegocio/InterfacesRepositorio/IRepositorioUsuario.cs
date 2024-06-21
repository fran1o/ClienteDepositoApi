using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfazRepositorio
{
    public interface IRepositorioUsuario
    {
        public string obtenerToken(Usuario usuario);

        public Usuario GetByEmail(string email);
    }
}
