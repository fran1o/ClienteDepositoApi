using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Movimientos
{
    public class CantidadTotal: ICantidadTotal<Movimiento>
    {

        IRepositorioMovimiento _repositorioMovimiento;

        public CantidadTotal(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }


        public int Ejecutar()
        {
            return _repositorioMovimiento.GetCount();
        }

      
    }
}