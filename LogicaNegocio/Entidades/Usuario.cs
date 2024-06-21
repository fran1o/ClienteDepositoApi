using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.ValueObjects;

namespace LogicaNegocio.Entidades
{
    public class Usuario: IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Discriminator { get; set; }

        public void Validar()
        {
        }
    }
}
