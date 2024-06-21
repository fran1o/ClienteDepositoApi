
namespace LogicaNegocio.IntefazServicios
{
    public interface IObtenerFiltroFecha <T>
    {
        public IEnumerable<T> Ejecutar(DateTime value);
    }
}
