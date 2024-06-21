
using LogicaNegocio.Entidades;
using WebApp.Models;

namespace LogicaNegocio.IntefazServicios
{
    public interface IObtenerRangoFecha <T>
    {
        public PageViewModel<Articulo> Ejecutar(DateTime desde, DateTime hasta, int page = 0);
    }
}
