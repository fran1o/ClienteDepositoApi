using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;
using WebApp.Models;


namespace LogicaAplicacion.Movimientos
{
    public class ObtenerMovimientos: IObtenerTodos<Movimiento>
    {

        IRepositorioMovimiento _repositorioMovimiento;

        public ObtenerMovimientos(IRepositorioMovimiento repositorioMovimiento, ITokenService tokenService)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }


        public PageMovimientoViewModel Ejecutar(int page = 0)
        {
            return _repositorioMovimiento.GetAll(page);
        }
    }
}