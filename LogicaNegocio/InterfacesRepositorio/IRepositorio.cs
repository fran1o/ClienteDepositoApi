

using WebApp.Models;

namespace LogicaNegocio.InterfazRepositorio
{
    public interface IRepositorio <T>
    {
        public void Add(T obj);
        public void Delete(int id);
        public void Update(int id, T obj);
        public T GetById( int id);
        public PageMovimientoViewModel GetAll(int page = 0);

    }
}
