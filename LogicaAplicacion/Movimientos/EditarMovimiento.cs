using Infraestructura.LogicaAccesoDatos.Dtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Movimientos
{
    public class EditarMovimiento : IEditar<MovimientoDto>
    {

        IRepositorioMovimiento _repositorioMovimiento;

        public EditarMovimiento(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }

        public void Ejecutar(int id, MovimientoDto mov)
        {
            _repositorioMovimiento.Update(id, mov);
        }

    }
}
