
using WebApp.Models;

namespace LogicaNegocio.IntefazServicios
{
    public interface IObtenerTodos <T>
    {
        public PageMovimientoViewModel Ejecutar(int page = 0);
    }
}
