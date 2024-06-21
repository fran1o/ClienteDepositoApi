using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Movimientos
{
    public class EliminarMovimiento : IEliminar<Movimiento>
    {
        IRepositorioMovimiento _repositorioMovimiento;

        public EliminarMovimiento(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }

        public void Ejecutar(int id)
        {
            _repositorioMovimiento.Delete(id);
        }
    }
}
