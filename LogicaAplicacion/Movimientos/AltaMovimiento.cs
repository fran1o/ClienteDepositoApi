using Infraestructura.LogicaAccesoDatos.Dtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Movimientos
{
    public class AltaMovimiento: IAlta<MovimientoDto>
    {
        IRepositorioMovimiento _repositorioMovimiento;

        public AltaMovimiento(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }

        public void Ejecutar(MovimientoDto movDto)
        {
            _repositorioMovimiento.Add(movDto);
        }

    }
}
