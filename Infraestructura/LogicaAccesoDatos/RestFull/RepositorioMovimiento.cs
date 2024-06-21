using LogicaNegocio.Entidades;
using System.Text.Json;
using LogicaNegocio.InterfazRepositorio;
using Infraestructura.LogicaAccesoDatos.Excepciones;
using Microsoft.EntityFrameworkCore;
using Azure;
using WebApp.Models;
using static System.Net.Mime.MediaTypeNames;
using Infraestructura.LogicaAccesoDatos.Dtos;

namespace Infraestructura.LogicaAccesoDatos.RestFull
{
    public class RepositorioMovimiento : IRepositorioMovimiento
    {

        //Esto seria el repositorio del movimiento

        private IRestFull _clientRest;
        private string token;


        public RepositorioMovimiento(IRestFull clientRest, ITokenService tokenService)
        {
            _clientRest = clientRest;
            token = tokenService.GetToken();
        }

        public void Add(MovimientoDto movDto)
        {
            Console.WriteLine(movDto.ArticuloId);
            Console.WriteLine(movDto.TipoMovId);
            Console.WriteLine(movDto.UsuarioId);
            string jsonEntity = JsonSerializer.Serialize(movDto);
            const string endPoint = "Movimientos";
            string json = _clientRest.Post(token, endPoint, jsonEntity);
            Console.WriteLine(jsonEntity);

        }

        public void Add(Movimiento obj)
        {
            string jsonEntity = JsonSerializer.Serialize(obj);
            const string endPoint = "Movimientos";
            string json = _clientRest.Post(token, endPoint, jsonEntity);
            obj = ToolsEntity<Movimiento>.ObjetcFromJson(json);
        }


        public void Delete(int id)
        {
            string resource = $"Movimientos/{id}";
            _clientRest.Delete(token, resource);
        }

        public IEnumerable<Movimiento> FindByName(string name)
        {
            string endPoint = "Movimientos";
            string json = _clientRest.Request(token, endPoint);
            return ToolsEntity<Movimiento>.ListFromJson(json);
        }


        public PageMovimientoViewModel GetAll(int page = 0)
        {
            string resource = $"Movimientos?page={page}";
            string json = _clientRest.Request(token, resource);

            var response = ToolsEntity<PageMovimientoViewModel>.ObjetcFromJson(json);

            return response;
        }

        public int GetCount()
        {
            string resource = "Movimientos/count";
            string json = _clientRest.Request(token, resource);
            double cantPaginas;
            double.TryParse(json, out cantPaginas);
            return (int)cantPaginas;

        }

        public Movimiento GetById(int id)
        {
            string resource = $"Movimientos/{id}";
            string json = _clientRest.Request(token, resource);
            return ToolsEntity<Movimiento>.ObjetcFromJson(json);
        }

        public IEnumerable<Movimiento> GetByName(string name)
        {
            throw new NotImplementedException();
        }


        public void Update(int id, MovimientoDto movDto)
        {
            string jsonEntity = JsonSerializer.Serialize(movDto);
            string endPoint = $"Movimientos/{id}";
            string json = _clientRest.Put(token, endPoint, jsonEntity);
        }

        public void Update(int id, Movimiento obj)
        {
            throw new NotImplementedException();
        }

        PageMovimientoViewModel IRepositorioMovimiento.GetMovimientosByTipoByArticulo(string articuloId, string tipoMov, int page)
        {
            string resource = $"Movimientos/ByTipoAndArticle?articuloId={articuloId}&tipoMov={tipoMov}&page={page}";
            string json = _clientRest.Request(token, resource);

            var response = ToolsEntity<PageMovimientoViewModel>.ObjetcFromJson(json);

            return response;
        }

        PageViewModel<Articulo> IRepositorioMovimiento.GetMovimientosByFechas(DateTime desde, DateTime hasta, int page)
        {
            string resource = $"Movimientos/ArticulosByDates?desde={desde.ToString("yyyy-MM-dd")}&hasta={hasta.ToString("yyyy-MM-dd")}&page={page}";
            string json = _clientRest.Request(token, resource);

            var response = ToolsEntity<PageViewModel<Articulo>>.ObjetcFromJson(json);

            return response;
        }

        IEnumerable<string> IRepositorioMovimiento.GetCantidadesMovimientos()
        {
            string resource = $"Movimientos/Cantidad";
            string json = _clientRest.Request(token, resource);

            var response = ToolsEntity<IEnumerable<string>>.ObjetcFromJson(json);

            return response;
        }
    }
    
}
