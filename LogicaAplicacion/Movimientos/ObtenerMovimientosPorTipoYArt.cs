using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;
using WebApp.Models;


namespace LogicaAplicacion.Movimientos
{
    public class ObtenerMovimientosPorTipoYArt: IObtenerFiltroDobleString<Movimiento>
    {

        IRepositorioMovimiento _repositorioMovimiento;

        public ObtenerMovimientosPorTipoYArt(IRepositorioMovimiento repositorioMovimiento, ITokenService tokenService)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }


        public PageMovimientoViewModel Ejecutar(string articuloId, string tipoMov, int page = 0)
        {
            return _repositorioMovimiento.GetMovimientosByTipoByArticulo(articuloId, tipoMov, page);
        }
    }
}