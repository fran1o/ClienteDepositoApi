using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class DatosInvalidosException : UsuarioException
    {
        public DatosInvalidosException() : base("Debe completar todos los campos") { }
    }
}
