
using LogicaNegocio.Entidades;
using WebApp.Models;

namespace LogicaNegocio.IntefazServicios
{
    public interface IObtenerFiltroDobleString<T>
    {
        public PageMovimientoViewModel Ejecutar(string primerValor, string segundoValor, int page = 0);
    }
}
