using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filtros
{
    public class Logueado :Attribute, IAuthorizationFilter
    {
        private string _rol;

        public Logueado(string rol)
        {
            _rol = rol;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string rol = context.HttpContext.Session.GetString("rol");
            if (rol != _rol)
            {
                context.Result = new RedirectResult("/user/index");
                return;
            }
        }
    }
}
