
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Articulo()
    {
        public int Id { get; set; }
        public Nombre NombreArt {  get; set; }
        public string Descripcion { get; set; }
        public long Codigo { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }


    }
}
