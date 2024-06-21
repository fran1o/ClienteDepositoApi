using Infraestructura.LogicaAccesoDatos.Dtos;
using LogicaNegocio.Entidades;
using WebApp.Models;

namespace LogicaNegocio.InterfazRepositorio
{
    public interface IRepositorioMovimiento: IRepositorio<Movimiento>
    {
        public IEnumerable<Movimiento> GetByName(string name);

        public void Add(MovimientoDto movDto);
        public int GetCount();

        public void Update(int id, MovimientoDto movDto);


        public PageMovimientoViewModel GetMovimientosByTipoByArticulo(string articuloId, string tipoMov, int page = 0);

        public PageViewModel<Articulo> GetMovimientosByFechas(DateTime desde, DateTime hasta, int page = 0);

        public IEnumerable<string> GetCantidadesMovimientos();

    }
}
