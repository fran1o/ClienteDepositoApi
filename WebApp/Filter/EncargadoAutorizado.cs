using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Filter
{
    public class EncargadoAutorizado : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine(context.HttpContext.Session.GetString("rol"));
            if (context.HttpContext.Session.GetString("rol") != "Encargado")
            {
                context.Result = new RedirectResult("/Usuario");
            }
        }
    }
}
