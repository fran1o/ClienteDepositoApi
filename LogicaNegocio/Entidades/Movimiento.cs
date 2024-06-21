using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Movimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Articulo Articulo { get; set; }

        public TipoMovimiento TipoMov { get; set; }
        public UsuarioDto Usuario { get; set; }

        public int Cantidad { get; set; }

    }
}
