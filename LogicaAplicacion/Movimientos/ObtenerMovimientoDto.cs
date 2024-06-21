using Infraestructura.LogicaAccesoDatos.Dtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefacesServicios;
using LogicaNegocio.InterfazRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Movimientos
{
    public class ObtenerMovimientoDto : IObtenerDto<MovimientoDto>
    {
        IRepositorioMovimiento _repositorioMovimiento;

        public ObtenerMovimientoDto(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }

        public MovimientoDto Ejecutar(int id)
        {
            Movimiento mov = _repositorioMovimiento.GetById(id);
            Console.WriteLine(mov);
            MovimientoDto movDto = new MovimientoDto();
            movDto.Id = id;
            movDto.Fecha = mov.Fecha;
            // Verificar y asignar propiedades relacionadas
            if (mov.Articulo != null)
            {
                movDto.ArticuloId = mov.Articulo.Id;
            }

            if (mov.TipoMov != null)
            {
                movDto.TipoMovId = mov.TipoMov.Id;
            }

            if (mov.Usuario != null)
            {
                movDto.UsuarioId = mov.Usuario.Id;
            }
            movDto.Cantidad = mov.Cantidad;


            return movDto;
        }
    }
}
