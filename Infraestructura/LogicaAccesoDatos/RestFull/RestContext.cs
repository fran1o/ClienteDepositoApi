
using RestSharp;
using System.Net;


namespace Infraestructura.LogicaAccesoDatos.RestFull;

public class RestContext : IRestFull
{
    // Clase genérica RestContext que implementa la interfaz IRestFull
    private RestClient _httpClient;
    private string _apiUrl = "";
    private RestRequest _request;


    // Recibo por inyeccion la url y creo el cliente. Se acopla al conocimiento de RestSharp
    public RestContext(string apiUrl)
    {
        _apiUrl = apiUrl;
        // Inicializa la URL base de la API con el valor proporcionado.
        _httpClient = new RestClient(_apiUrl);
    }


    // Recibe el Recurso y devuelve el json son el resultado de la request
    public String Request(string token, string endPoint)
    {
        var _request = new RestRequest(endPoint);
        _request.AddHeader("Contet-Type", "application/json");
        _request.AddHeader("Authorization", $"Bearer {token}");
        var response = _httpClient.ExecuteGet(_request);
        if (response.Content == null)
        {
            throw new Exception("El json esta vacio");
        }
        return response.Content;
    }

  
    // Recibe el Recurso y el json a dar de alta
    public string Post(string token, string endPoint, string json)
    {

        var _request = new RestRequest(endPoint);

        _request.AddHeader("Contet-Type", "application/json");
        _request.AddHeader("Authorization", $"Bearer {token}");
        _request.AddBody(json);
        var response = _httpClient.ExecutePost(_request);
        if (response.Content == null)
        {
            throw new Exception("El json esta vacio");
        }
        return response.Content;
    }

    public string Put(string token, string endPoint, string jsonEntity)
    {
        var request = new RestRequest(endPoint, Method.Put);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Authorization", $"Bearer {token}");
        request.AddParameter("application/json", jsonEntity, ParameterType.RequestBody);

        var response = _httpClient.Execute(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Error al hacer la solicitud PUT: {response.StatusCode}, {response.ErrorMessage}");
        }

        return response.Content;
    }

    // Recibe el Recurso y devuelve el json son el resultado de la request
    public void Delete(string token, string endPoint)
    {
        var _request = new RestRequest(endPoint, Method.Delete);
        _request.AddHeader("Contet-Type", "application/json");
        _request.AddHeader("Authorization", $"Bearer {token}");
        _httpClient.Execute(_request);
    }

}



