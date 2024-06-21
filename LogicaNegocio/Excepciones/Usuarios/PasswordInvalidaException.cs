using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class PasswordInvalidaException : UsuarioException
    {
        public PasswordInvalidaException() : base("Contraseña incorrecta") { }
    }
}
