using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Movimientos
{
    public class ObtenerMovimientoCantidades: IObtenerElementos<string>
    {

        IRepositorioMovimiento _repositorioMovimiento;

        public ObtenerMovimientoCantidades(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }

        public IEnumerable<string> Ejecutar()
        {
            return _repositorioMovimiento.GetCantidadesMovimientos();
        }

    }
}
