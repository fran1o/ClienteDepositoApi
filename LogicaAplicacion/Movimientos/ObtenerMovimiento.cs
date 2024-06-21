using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Movimientos
{
    public class ObtenerMovimiento: IObtener<Movimiento>
    {

        IRepositorioMovimiento _repositorioMovimiento;

        public ObtenerMovimiento(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }

        public Movimiento Ejecutar(int id)
        {
            return _repositorioMovimiento.GetById(id);
        }

    }
}
