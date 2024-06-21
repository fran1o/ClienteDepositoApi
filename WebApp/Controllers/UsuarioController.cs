using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Dtos.Dto;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Usuarios;
using LogicaNegocio.IntefacesServicios;
using LogicaNegocio.IntefazServicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private ILogin _usuarioLogin;
        private IObtenerByEmail<Usuario> _obtenerUsuarioByEmail;

        public UsuarioController(
           ILogin usuarioLogin,
           IObtenerByEmail<Usuario> obtenerUsuarioByEmail
        )
        {
            _usuarioLogin = usuarioLogin;
            _obtenerUsuarioByEmail = obtenerUsuarioByEmail;
        }

        public IActionResult Index()
        {
            string userEmail = HttpContext.Session.GetString("mail");

            if (userEmail != null) return Redirect("/Movimiento/Index");

            return View();
        }

        public IActionResult Login(Usuario usuario)
        {

            try
            {
                if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Password))
                {
                    throw new DatosInvalidosException();
                }
                Usuario nuevoUsuario = _obtenerUsuarioByEmail.Ejecutar(usuario.Email);
                if (nuevoUsuario == null)
                {
                    throw new UsuarioInvalidaException();
                }

                var tokenString = _usuarioLogin.Ejecutar(usuario); // Suponiendo que esto devuelve el token JWT como string
                Console.WriteLine(tokenString);
               
                DecodeJwt(tokenString);

                
                // Deserializar el token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(tokenString);

                // Ejemplo de acceso a las claims del token
                var rolClaim = token.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
                var emailClaim = token.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

                HttpContext.Session.SetString("rol", rolClaim);
                HttpContext.Session.SetString("mail", emailClaim);
                HttpContext.Session.SetString("token", tokenString);
                return Redirect("/Usuario");
            }
            catch (DatosInvalidosException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (UsuarioInvalidaException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
            }

            return View("Index");

        }


        public static void DecodeJwt(string token)
        {
            try
            {
                // Ensure the token is well-formed
                if (string.IsNullOrEmpty(token) || token.Count(c => c == '.') != 2)
                {
                    Console.WriteLine("Invalid JWT format.");
                    throw new Exception(token);

                }

                var handler = new JwtSecurityTokenHandler();

                if (!handler.CanReadToken(token))
                {
                    Console.WriteLine("Cannot read token.");
                    return;
                }

                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jsonToken == null)
                {
                    Console.WriteLine("Invalid token.");
                    return;
                }

                // Print the claims
                foreach (var claim in jsonToken.Claims)
                {
                    Console.WriteLine($"{claim.Type}: {claim.Value}");
                }

                // Optionally, if you want to get a specific claim, you can do it like this:
                var specificClaim = jsonToken.Claims.FirstOrDefault(c => c.Type == "your-claim-type")?.Value;
                Console.WriteLine($"Your specific claim: {specificClaim}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string getHashSHA256(string value)
        {
            using var hash = SHA256.Create();
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
            return Convert.ToHexString(byteArray);
        }
        public void Logout()
        {
            HttpContext.Session.Clear();
        }



    }

}

