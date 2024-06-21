using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;
using WebApp.Models;


namespace LogicaAplicacion.Movimientos
{
    public class ObtenerMovimientosPorFechas : IObtenerRangoFecha<Articulo>
    {

        IRepositorioMovimiento _repositorioMovimiento;

        public ObtenerMovimientosPorFechas(IRepositorioMovimiento repositorioMovimiento, ITokenService tokenService)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }


        public PageViewModel<Articulo> Ejecutar(DateTime desde, DateTime hasta, int page = 0)
        {
            return _repositorioMovimiento.GetMovimientosByFechas(desde, hasta, page);
        }
    }
}