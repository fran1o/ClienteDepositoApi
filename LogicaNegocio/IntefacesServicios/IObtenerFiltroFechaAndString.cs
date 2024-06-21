
namespace LogicaNegocio.IntefazServicios
{
    public interface IObtenerFiltroFechaAndString <T>
    {
        public IEnumerable<T> Ejecutar(DateTime fecha, string value);
    }
}
