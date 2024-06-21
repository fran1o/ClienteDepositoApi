
namespace LogicaNegocio.IntefazServicios
{
    public interface IObtenerFiltroString <T>
    {
        public IEnumerable<T> Ejecutar(string value);
    }
}
