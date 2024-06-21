using Infraestructura.LogicaAccesoDatos.Dtos;
using Infraestructura.LogicaAccesoDatos.RestFull;
using LogicaAplicacion.CasoUso.Usuarios;
using LogicaAplicacion.Movimientos;
using LogicaAplicacion.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefacesServicios;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;
namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // servicio para guardar el token y solicitarlo donde lo necesite usar
            // 
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<ITokenService, TokenService>();
            builder.Services.AddSession();

            // para usar la api, debo indicar el servidor 
            // para arma el endPoint el recurso esta en cada
            // repositorio
            builder.Services.AddScoped<IRestFull>(provider => new RestContext(builder.Configuration.GetConnectionString("apiUrl")));

            // inyecta los repositorio concretos de EF
            builder.Services.AddScoped<IRepositorioMovimiento, RepositorioMovimiento>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            //caso de uso usuario
            builder.Services.AddScoped<IObtenerByEmail<Usuario>, ObtenerUsuarioByEmail>();

            // caso de uso movimiento
            builder.Services.AddScoped<IAlta<MovimientoDto>, AltaMovimiento>();
            builder.Services.AddScoped<IEliminar<Movimiento>, EliminarMovimiento>();
            builder.Services.AddScoped<IEditar<MovimientoDto>, EditarMovimiento>();
            builder.Services.AddScoped<IObtener<Movimiento>, ObtenerMovimiento>();
            builder.Services.AddScoped<IObtenerDto<MovimientoDto>, ObtenerMovimientoDto>();
            builder.Services.AddScoped<IObtenerTodos<Movimiento>, ObtenerMovimientos>();
            builder.Services.AddScoped<ICantidadTotal<Movimiento>, CantidadTotal>();
            builder.Services.AddScoped<IObtenerFiltroDobleString<Movimiento>, ObtenerMovimientosPorTipoYArt>();
            builder.Services.AddScoped<IObtenerRangoFecha<Articulo>, ObtenerMovimientosPorFechas>();
            builder.Services.AddScoped<IObtenerElementos<string>, ObtenerMovimientoCantidades>();
 

            // caso de uso login
            builder.Services.AddScoped<ILogin, ObtenerToken>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();
            // app.UseTokenMiddleware();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuario}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
