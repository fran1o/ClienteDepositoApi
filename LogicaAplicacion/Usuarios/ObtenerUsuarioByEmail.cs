using LogicaNegocio.Dtos.Dto;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefacesServicios;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Usuarios
{
    public class ObtenerUsuarioByEmail : IObtenerByEmail<Usuario>
    {

        IRepositorioUsuario _repositorioUsuario;

        public ObtenerUsuarioByEmail(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public Usuario Ejecutar(string Email)
        {
            return _repositorioUsuario.GetByEmail(Email);
        }

    }
}
