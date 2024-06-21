using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.ValueObjects;

namespace LogicaNegocio.Entidades
{
    public class UsuarioDto 
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Discriminator { get; set; }

 
    }
}
