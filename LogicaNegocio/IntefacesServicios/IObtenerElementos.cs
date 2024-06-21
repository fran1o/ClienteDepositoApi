
namespace LogicaNegocio.IntefazServicios
{
    public interface IObtenerElementos <T>
    {
        public IEnumerable<T> Ejecutar();
    }
}
