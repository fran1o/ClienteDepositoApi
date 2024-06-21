using LogicaNegocio.Entidades;
using System.Text.Json;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.Dtos.Dto;

namespace Infraestructura.LogicaAccesoDatos.RestFull
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        private IRestFull _clientRest;
        private string token;

        public RepositorioUsuario(IRestFull clientRest)
        {
            _clientRest = clientRest;

        }

        public Usuario GetByEmail(string email)
        {
            string endPoint = $"Usuarios";
            string json = _clientRest.Request(token, endPoint);

            // Deserializar el JSON a una lista de usuarios
            var usuarios = (List<Usuario>)ToolsEntity<Usuario>.ListFromJson(json);
            // Captramos el usuario por el email
            Usuario usuario = usuarios.FirstOrDefault(u => u.Email == email);

            return usuario;

        }

        public string obtenerToken(Usuario usuario)
        {
            var user = new UserDto()
            {
                Email = usuario.Email,
                Password = usuario.Password
            };

            string jsonEntity = JsonSerializer.Serialize(user);
            const string endPoint = "Usuarios";
            string json = _clientRest.Post("", endPoint, jsonEntity);
            string token = ToolsEntity<string>.ObjetcFromJson(json);
            return token;
        }


    }
}
